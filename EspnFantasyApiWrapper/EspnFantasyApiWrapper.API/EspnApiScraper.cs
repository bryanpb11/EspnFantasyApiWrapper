﻿using System.Text.Json;

using EspnFantasyApiWrapper.API.Model;
using EspnRosterModel = EspnFantasyApiWrapper.API.Model.EspnRoster;
using EspnTeamModel = EspnFantasyApiWrapper.API.Model.EspnTeam;

namespace EspnFantasyApiWrapper.API
{
    public class EspnApiScraper
    {
        private readonly HttpClient _httpClient;
        private readonly string _urlRoot;

        public EspnApiScraper(HttpClient httpClient, string apiUrlRoot = "https://lm-api-reads.fantasy.espn.com/apis/v3/games/flb/leagueHistory/")
        {
            _httpClient = httpClient;
            _urlRoot = apiUrlRoot;
        }

        public async Task<List<PlayerStats>> ProcessRosterData(string leagueId, string season)
        {
            var data = await ScrapeRosterData(leagueId, season);
            var roster = data.FirstOrDefault();
            List<PlayerStats> lPlayerStats = new();

            foreach(var team in roster.Teams)
            {
                var teamId = team.Id;
                
                foreach(var entry in team.Roster.Entries)
                {
                    var playerName = entry.PlayerPoolEntry.Player.FullName;
                    var statsAppliedTotal = entry.PlayerPoolEntry.Player.Stats != null ? entry.PlayerPoolEntry.Player.Stats[0].AppliedTotal : 0;
                    var statsAppliedAverage = entry.PlayerPoolEntry.Player.Stats != null ? entry.PlayerPoolEntry.Player.Stats[0].AppliedAverage : 0;
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

        public async Task<List<EspnRosterModel.Roster>> ScrapeRosterData(string leagueId, string season)
        {
            List<EspnRosterModel.Roster> roster = new();
            var url = $"{_urlRoot}{leagueId}?seasonId={season}&view=mRoster"; // Replace with actual API URL
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                try
                {
                    roster = JsonSerializer.Deserialize<List<EspnRosterModel.Roster>>(jsonResponse);
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
    
        public async Task<List<TeamStats>> ProcessTeamData(string leagueId, string season)
        {
            var data = await ScrapeTeamData(leagueId, season);
            var teamData = data.FirstOrDefault();
            List<TeamStats> lTeamStats = new();
            var members = teamData.Members;

            foreach (var team in teamData.Teams)
            {
                var teamId = team.Id;
                
                var teamMember = members.FirstOrDefault(m => m.Id == team.PrimaryOwner);

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

        public async Task<List<EspnTeamModel.TeamData>> ScrapeTeamData(string leagueId, string season)
        {
            List<EspnTeamModel.TeamData> teams = new();
            var url = $"{_urlRoot}{leagueId}?seasonId={season}&view=mTeam"; // Replace with actual API URL
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                try
                {
                    teams = JsonSerializer.Deserialize<List<EspnTeamModel.TeamData>>(jsonResponse);
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
