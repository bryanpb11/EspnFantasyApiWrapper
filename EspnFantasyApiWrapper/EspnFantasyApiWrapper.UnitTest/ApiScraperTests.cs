using EspnFantasyApiWrapper.API;
using Xunit;

namespace EspnFantasyApiWrapper.UnitTest;

public class ApiScraperTests
{
    private readonly HttpClient _httpClient;
    private readonly APIScraper _apiScraper;
    private readonly string _apiUrlRoot = "https://lm-api-reads.fantasy.espn.com/apis/v3/games/flb/leagueHistory/";
    private readonly string _leagueId = Environment.GetEnvironmentVariable("FantasyLeagueID") ?? "";
    private readonly string _season = "2024";

    //replace with your own values here
    private readonly string _player5Name = "George Kirby";
    private readonly int _team1Player3Id = 42402;
    private readonly string _team8Name = "Threat Level Midnight";
    private readonly string _team1Abbrev = "MW";

    public ApiScraperTests()
    {
        _httpClient = new HttpClient();
        _apiScraper = new APIScraper(_httpClient, _apiUrlRoot);
    }

    [Fact]
    public async Task ProcessRosterData_ReturnsPlayerStatsList()
    {
        // Act
        var result = await _apiScraper.ProcessRosterData(_leagueId, _season);

        // Assert
        Xunit.Assert.NotNull(result);
        Xunit.Assert.Equal(_player5Name, result[4].PlayerName);
    }

    [Fact]
    public async Task ScrapeRosterData_ReturnsRosterList()
    {
        // Act
        var result = await _apiScraper.ScrapeRosterData(_leagueId, _season);

        // Assert
        Xunit.Assert.NotNull(result);
        Xunit.Assert.Single(result);
        Xunit.Assert.Equal(_team1Player3Id, result[0].Teams[1].Roster.Entries[2].PlayerId);
    }

    [Fact]
    public async Task ProcessTeamData_ReturnsTeamStatsList()
    {   
        // Act
        var result = await _apiScraper.ProcessTeamData(_leagueId, _season);

        // Assert
        Xunit.Assert.NotNull(result);
        Xunit.Assert.Equal(_team8Name, result[7].TeamName);
    }

    [Fact]
    public async Task ScrapeTeamData_ReturnsTeamDataList()
    {
        // Act
        var result = await _apiScraper.ScrapeTeamData(_leagueId, _season);

        // Assert
        Xunit.Assert.NotNull(result);
        Xunit.Assert.Single(result);
        Xunit.Assert.Equal(_team1Abbrev, result[0].Teams[0].Abbrev);
    }
}
