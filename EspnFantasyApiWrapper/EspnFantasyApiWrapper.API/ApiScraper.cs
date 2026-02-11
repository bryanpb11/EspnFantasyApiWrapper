using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using EspnFantasyApiWrapper.API.Model;
using EspnRosterModel = EspnFantasyApiWrapper.API.Model.EspnRoster;
using EspnTeamModel = EspnFantasyApiWrapper.API.Model.EspnTeam;

namespace EspnFantasyApiWrapper.API
{
    /// <summary>
    /// Constructor for EspnApiScraper
    /// </summary>
    /// <param name="httpClient">An instantiated HttpClient object</param>
    /// <param name="apiUrlRoot">The root Url for the API call to the ESPN League History API.  Default root for Fantasy Baseball is https://lm-api-reads.fantasy.espn.com/apis/v3/games/flb/leagueHistory/.  To get details about other endpoints, browse to: https://lm-api-reads.fantasy.espn.com/apis/v3/games</param>
    public class APIScraper
    {
        private readonly HttpClient _httpClient;
        private readonly string _urlRoot;
        private readonly string? _cookieHeader;

        public APIScraper(HttpClient httpClient, string apiUrlRoot = "https://lm-api-reads.fantasy.espn.com/apis/v3/games/flb/leagueHistory/", string? swid = null, string? espnS2 = null)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _urlRoot = apiUrlRoot ?? throw new ArgumentNullException(nameof(apiUrlRoot));

            if (!string.IsNullOrEmpty(swid) || !string.IsNullOrEmpty(espnS2))
            {
                var parts = new List<string>();
                if (!string.IsNullOrEmpty(swid)) parts.Add($"SWID={swid}");
                if (!string.IsNullOrEmpty(espnS2)) parts.Add($"espn_s2={espnS2}");
                _cookieHeader = string.Join("; ", parts);
            }
            else
            {
                _cookieHeader = null;
            }
        }

        private HttpRequestMessage CreateGetRequest(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            if (!string.IsNullOrEmpty(_cookieHeader))
            {
                // Attach authentication cookies required by ESPN fantasy API
                request.Headers.Add("Cookie", _cookieHeader!);
            }

            return request;
        }

        /// <summary>
        /// Scrapes raw data from ESPN API and processes it into a list of simplified PlayerStats objects
        /// </summary>
        /// <param name="leagueId">ESPN League ID</param>
        /// <param name="season">Fantasy season year</param>
        /// <returns>Simplified list of PlayerStats objects</returns>
        public async Task<List<PlayerStats>> ProcessRosterData(string leagueId, string season, string sportAbbrev)
        {
            var data = await ScrapeRosterData(leagueId, season);
            var roster = data.FirstOrDefault() ?? new EspnRosterModel.Roster();
            
            var playerStatIndex = sportAbbrev switch
            {
                "flb" => 0,
                "ffl" => 1,
                _ => -1,
            };

            List<PlayerStats> lPlayerStats = new List<PlayerStats>();

            if (roster.Teams == null) return lPlayerStats;

            foreach(var team in roster.Teams)
            {
                var teamId = team.Id;
                
                if (team.Roster?.Entries == null) continue;

                foreach(var entry in team.Roster.Entries)
                {
                    var playerName = entry.PlayerPoolEntry.Player.FullName;
                    var statsAppliedTotal = entry.PlayerPoolEntry.Player.Stats != null && playerStatIndex >= 0 ? entry.PlayerPoolEntry.Player.Stats[playerStatIndex].AppliedTotal : 0;
                    var statsAppliedAverage = entry.PlayerPoolEntry.Player.Stats != null && playerStatIndex >= 0 ? entry.PlayerPoolEntry.Player.Stats[playerStatIndex].AppliedAverage : 0;
                    var lineupSlotId = entry.LineupSlotId;
                    var playerId = entry.PlayerPoolEntry.Player.Id;
                    var year = season;
                    var defaultPositionId = entry.PlayerPoolEntry.Player.DefaultPositionId;

                    var playerStats = new PlayerStats
                    {
                        TeamId = teamId,
                        PlayerName = playerName,
                        DefaultPositionId = defaultPositionId,
                        StatsAppliedTotal = Convert.ToDecimal(statsAppliedTotal),
                        StatsAppliedAverage = Convert.ToDecimal(statsAppliedAverage),
                        LineupSlotId = lineupSlotId,
                        PlayerId = playerId,
                        Year = year
                    };

                    lPlayerStats.Add(playerStats);
                }
            }

            return lPlayerStats;
        }

        /// <summary>
        /// Scrapes raw roster data from ESPN API
        /// </summary>
        /// <param name="leagueId">ESPN League ID</param>
        /// <param name="season">Fantasy season year</param>
        /// <returns>List of raw roster data</returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<EspnRosterModel.Roster>> ScrapeRosterData(string leagueId, string season)
        {
            List<EspnRosterModel.Roster> roster = new List<EspnRosterModel.Roster>();
            var url = $"{_urlRoot}{leagueId}?seasonId={season}&view=mRoster"; // Replace with actual API URL
            var request = CreateGetRequest(url);
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                try
                {
                    roster = JsonSerializer.Deserialize<List<EspnRosterModel.Roster>>(jsonResponse) ?? new List<EspnRosterModel.Roster>();
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                }
            }
            else
            {
                throw new Exception("Failed to retrieve roster data");
            }

            return roster;
        }

        /// <summary>
        /// Processes raw team data from ESPN API into a list of simplified TeamStats objects
        /// </summary>
        /// <param name="leagueId">ESPN League ID</param>
        /// <param name="season">Fantasy season year</param>
        /// <returns>Simplified list of TeamStats objects</returns>
        public async Task<List<TeamStats>> ProcessTeamData(string leagueId, string season)
        {
            var data = await ScrapeTeamData(leagueId, season);
            var teamData = data.FirstOrDefault() ?? new EspnTeamModel.TeamData();
            List<TeamStats> lTeamStats = new List<TeamStats>();
            var members = teamData.Members ?? new List<EspnTeamModel.Member>();

            if (teamData.Teams == null) return lTeamStats;

            foreach (var team in teamData.Teams)
            {
                var teamId = team.Id;
                
                var teamMember = members.FirstOrDefault(m => m.Id == team.PrimaryOwner) ?? new EspnTeamModel.Member();

                var teamStats = new TeamStats
                {
                    TeamId = teamId,
                    TeamName = team.Name,
                    Year = season,
                    PrimaryOwnerId = team.PrimaryOwner,
                    PrimaryOwnerFirstName = teamMember.FirstName,
                    PrimaryOwnerLastName = teamMember.LastName,
                    PlayoffSeed = team.PlayoffSeed,
                    Points = Convert.ToDecimal(team.Points),
                    Wins = team.Record.Overall.Wins,
                    Losses = team.Record.Overall.Losses

                };

                lTeamStats.Add(teamStats);
            }

            return lTeamStats;
        }

        /// <summary>
        /// Scrapes raw team data from ESPN API
        /// </summary>
        /// <param name="leagueId">ESPN League ID</param>
        /// <param name="season">Fantasy season year</param>
        /// <returns>List of TeamData objects parsed from ESPN API</returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<EspnTeamModel.TeamData>> ScrapeTeamData(string leagueId, string season)
        {
            List<EspnTeamModel.TeamData> teams = new List<EspnTeamModel.TeamData>();
            var url = $"{_urlRoot}{leagueId}?seasonId={season}&view=mTeam"; // Replace with actual API URL
            var request = CreateGetRequest(url);
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                try
                {
                    teams = JsonSerializer.Deserialize<List<EspnTeamModel.TeamData>>(jsonResponse) ?? new List<EspnTeamModel.TeamData>();
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                }
            }
            else
            {
                throw new Exception("Failed to retrieve team data");
            }

            return teams;
        }
    }
}
