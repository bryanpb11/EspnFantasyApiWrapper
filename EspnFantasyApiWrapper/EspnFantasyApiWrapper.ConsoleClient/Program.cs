using EspnFantasyApiWrapper.API;

using System.Text.Json;

Console.WriteLine("Enter most recent season (year) to scrape to:");
var season = Convert.ToInt32(Console.ReadLine());
var origSeason = season;

Console.WriteLine("Enter season (year) to scrap back to:");
var goBackToSeason = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter League ID or blank to default to environment variable (FantasyLeagueID): ");
var leagueIdInput = Console.ReadLine();
var leagueId = String.IsNullOrWhiteSpace(leagueIdInput) ? Environment.GetEnvironmentVariable("FantasyLeagueID") ?? "" : leagueIdInput;

Console.WriteLine(@"Enter Root Url or blank for default (https://lm-api-reads.fantasy.espn.com/apis/v3/games/flb/leagueHistory/): ");
var apiUrlRootInput = Console.ReadLine();
var apiUrlRoot = String.IsNullOrWhiteSpace(apiUrlRootInput) ? "https://lm-api-reads.fantasy.espn.com/apis/v3/games/flb/leagueHistory/" : apiUrlRootInput;

using HttpClient httpClient = new();
APIScraper apiScraper = new(httpClient, apiUrlRoot);

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
                var apiResult2 = await apiScraper.ProcessRosterData(leagueId, season.ToString());
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