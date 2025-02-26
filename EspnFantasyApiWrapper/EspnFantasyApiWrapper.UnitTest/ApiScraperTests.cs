using EspnFantasyApiWrapper.API;
using Xunit;

namespace EspnFantasyApiWrapper.UnitTest;

public class ApiScraperTests
{
    private readonly HttpClient _baseballHttpClient;
    private readonly APIScraper _baseballApiScraper;
    private readonly string _baseballApiUrlRoot = "https://lm-api-reads.fantasy.espn.com/apis/v3/games/flb/leagueHistory/";
    private readonly string _baseballLeagueId = Environment.GetEnvironmentVariable("FantasyLeagueID") ?? "";
    private readonly string _baseballSeason = "2024";

    private readonly HttpClient _footballHttpClient;
    private readonly APIScraper _footballApiScraper;
    private readonly string _footballApiUrlRoot = "https://lm-api-reads.fantasy.espn.com/apis/v3/games/ffl/leagueHistory/";
    private readonly string _footballLeagueId = Environment.GetEnvironmentVariable("FantasyFootballLeagueID") ?? "";
    private readonly string _footballSeason = "2023";

    //replace with your own values here
    private readonly string _baseballPlayer5Name = "George Kirby";
    private readonly int _baseballTeam1Player3Id = 42402;
    private readonly string _baseballTeam8Name = "Threat Level Midnight";
    private readonly string _baseballTeam1Abbrev = "MW";

    private readonly string _footballTeam1Abbrev = "1A3T";
    private readonly string _footballTeam8Name = "Philly Specials";

    public ApiScraperTests()
    {
        _baseballHttpClient = new HttpClient();
        _baseballApiScraper = new APIScraper(_baseballHttpClient, _baseballApiUrlRoot);

        _footballHttpClient = new HttpClient();
        _footballApiScraper = new APIScraper(_footballHttpClient, _footballApiUrlRoot);
    }

    [Fact]
    public async Task Baseball_ProcessRosterData_ReturnsPlayerStatsList()
    {
        // Act
        var result = await _baseballApiScraper.ProcessRosterData(_baseballLeagueId, _baseballSeason, "flb");

        // Assert
        Xunit.Assert.NotNull(result);
        Xunit.Assert.Equal(_baseballPlayer5Name, result[4].PlayerName);
    }

    [Fact]
    public async Task Baseball_ScrapeRosterData_ReturnsRosterList()
    {
        // Act
        var result = await _baseballApiScraper.ScrapeRosterData(_baseballLeagueId, _baseballSeason);

        // Assert
        Xunit.Assert.NotNull(result);
        Xunit.Assert.Single(result);
        Xunit.Assert.Equal(_baseballTeam1Player3Id, result[0].Teams[1].Roster.Entries[2].PlayerId);
    }

    [Fact]
    public async Task Baseball_ProcessTeamData_ReturnsTeamStatsList()
    {   
        // Act
        var result = await _baseballApiScraper.ProcessTeamData(_baseballLeagueId, _baseballSeason);

        // Assert
        Xunit.Assert.NotNull(result);
        Xunit.Assert.Equal(_baseballTeam8Name, result[7].TeamName);
    }

    [Fact]
    public async Task Baseball_ScrapeTeamData_ReturnsTeamDataList()
    {
        // Act
        var result = await _baseballApiScraper.ScrapeTeamData(_baseballLeagueId, _baseballSeason);

        // Assert
        Xunit.Assert.NotNull(result);
        Xunit.Assert.Single(result);
        Xunit.Assert.Equal(_baseballTeam1Abbrev, result[0].Teams[0].Abbrev);
    }

    [Fact]
    public async Task Football_ScrapeTeamData_ReturnsTeamDataList()
    {
        // Act
        var result = await _footballApiScraper.ScrapeTeamData(_footballLeagueId, _footballSeason);

        // Assert
        Xunit.Assert.NotNull(result);
        Xunit.Assert.Single(result);
        Xunit.Assert.Equal(_footballTeam1Abbrev, result[0].Teams[0].Abbrev);
    }

    [Fact]
    public async Task Football_ProcessTeamData_ReturnsTeamStatsList()
    {
        // Act
        var result = await _footballApiScraper.ProcessTeamData(_footballLeagueId, _footballSeason);

        // Assert
        Xunit.Assert.NotNull(result);
        Xunit.Assert.Equal(_footballTeam8Name, result[7].TeamName);
    }
}
