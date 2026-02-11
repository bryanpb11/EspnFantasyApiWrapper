using EspnFantasyApiWrapper.API;

using System.Text.Json;

//To get these values, log into your ESPN account, open the developer tools in your browser
//and look for the "Cookie" header in the network requests to the ESPN fantasy API.
//This is located under "Application" -> "Storage" -> "Cookies" in Chrome Developer Tools.
//The SWID and espn_s2 values will be included in that header.
//You can set these as environment variables on your machine or input them when prompted by the console application.
var swid = Environment.GetEnvironmentVariable("ESPN_SWID");
var espnS2 = Environment.GetEnvironmentVariable("ESPN_S2");

Console.WriteLine("Enter most recent season (year) to scrape to:");
var season = Convert.ToInt32(Console.ReadLine());
var origSeason = season;

Console.WriteLine("Enter season (year) to scrap back to (blank for default of 2021):");
var input = Console.ReadLine();
var goBackToSeason = Convert.ToInt32(String.IsNullOrWhiteSpace(input) ? "2021" : input); 

Console.WriteLine("Enter League ID or blank to default to environment variable (FantasyLeagueID): ");
var leagueIdInput = Console.ReadLine();
var leagueId = String.IsNullOrWhiteSpace(leagueIdInput) ? Environment.GetEnvironmentVariable("FantasyLeagueID") ?? "" : leagueIdInput;

Console.WriteLine(@"Enter Root Url or blank for default (https://lm-api-reads.fantasy.espn.com/apis/v3/games/flb/leagueHistory/): ");
var apiUrlRootInput = Console.ReadLine();
var apiUrlRoot = String.IsNullOrWhiteSpace(apiUrlRootInput) ? "https://lm-api-reads.fantasy.espn.com/apis/v3/games/flb/leagueHistory/" : apiUrlRootInput;

Console.WriteLine(@"Enter sport abbreviation ('flb' for baseball (default), 'ffl' for football)");
input = Console.ReadLine();
var sportAbbrev = String.IsNullOrWhiteSpace(input) ? "flb" : input;

using HttpClient httpClient = new();
APIScraper apiScraper = new(httpClient, apiUrlRoot, swid, espnS2);

var choice = "";

while (choice != "X")
{
    Console.WriteLine("Pick an option to run:");

    var apiResultFull = new List<object>();
    var fileNamePrefix = "";

    Console.WriteLine("1 - Scrape raw fantasy team roster data and stats from the ESPN API and output to a local JSON file.");
    Console.WriteLine("2 - Scrape raw fantasy team roster data and stats from the ESPN API and output to a simplified JSON file.");
    Console.WriteLine("3 - Scrape raw fantasy team level data and stats from the ESPN API and output to a local JSON file.");
    Console.WriteLine("4 - Scrape raw fantasy team level data and stats from the ESPN API and output to a simplified JSON file.");
    Console.WriteLine("X - EXIT");
    Console.WriteLine("");

    choice = Console.ReadLine()?.ToUpper();
    Console.WriteLine("");
    
    while (season >= goBackToSeason)
    {
        switch (choice)
        {
            case "1":
                var apiResult1 = await apiScraper.ScrapeRosterData(leagueId, season.ToString());
                apiResultFull.AddRange(apiResult1);
                fileNamePrefix = "RawRoster";
                break;
            case "2":
                var apiResult2 = await apiScraper.ProcessRosterData(leagueId, season.ToString(), sportAbbrev);
                apiResultFull.AddRange(apiResult2);
                fileNamePrefix = "SimplifiedRoster";
                break;
            case "3":
                var apiResult3 = await apiScraper.ScrapeTeamData(leagueId, season.ToString());
                apiResultFull.AddRange(apiResult3);
                fileNamePrefix = "RawTeam";
                break;
            case "4":
                var apiResult4 = await apiScraper.ProcessTeamData(leagueId, season.ToString());
                apiResultFull.AddRange(apiResult4);
                fileNamePrefix = "SimplifiedTeam";
                break;
            case "X":
                break;
            default:
                Console.WriteLine("Invalid Option!!!");
                break;
        }

        season--;
    }

    if(choice == "X")
    {
        break;
    }
        
    var jsonOutput = JsonSerializer.Serialize(apiResultFull);

    var filePathTeam = Path.Combine(Directory.GetCurrentDirectory(), $"Data_{fileNamePrefix}_{DateTime.Now:yyyMMdd_hhmmssfff}.json");

    await File.WriteAllTextAsync(filePathTeam, jsonOutput);

    Console.WriteLine($"Data written to {filePathTeam}");

    season = origSeason;

    Console.WriteLine("");
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine("");
}

Console.WriteLine("Hit any key to exit!");