# EspnFantasyApiWrapper
The ESPN Fantasy API Wrapper repo is built in .NET/C# and contains wrappers to call into the ESPN fantasy sports APIs to pull various data.  This solution is currently built for the fantasy baseball endpoints (focusing on a H2H points league) and schemas but can be easily extended to support other fantasy sports.  Future development plans TBD.  Currently working on a separate project with ML.NET to use the stats from this project to make predictions for the upcoming season.

## Features
- Scrape raw fantasy team data/stats and player data/stats from the ESPN API.
- Output data to local JSON files in both raw and simplified formats (a subset of fields).
- Includes unit tests for the API wrapper code.

## Project Structure
The main Visual Studio solution file is "EspnFantasyApiWrapper\EspnFantasyApiWrapper.sln" and contains 3 projects.

1. EspnFantasyApiWrapper.API - This is the main class library project that contains all of the API wrapper code.  Functions and classes are self-documented with comments.
2. EspnFantasyApiWrapper.API.UnitTests - This is the unit test project for the EspnFantasyApiWrapper.API project, which has test coverage for all functions in the ApiScraper.cs file.  The readonly variables at the top of the "ApiScraperTests.cs" file must be changed for your league's data/test cases.
3. EspnFantasyApiWrapper.ConsoleClient - This is a sample console application that shows how to use the API wrapper code.  It currently has 4 options:
	1. Scrape raw fantasy team roster data and stats from the ESPN API and output to a local JSON file.
	2. Scrape raw fantasy team roster data and stats from the ESPN API and output to a simplified JSON file.
	3. Scrape raw fantasy team level data and stats from the ESPN API and output to a local JSON file.
	4. Scrape raw fantasy team level data and stats from the ESPN API and output to a simplified JSON file.
## ESPN API Endpoints
This section contains some brief notes on the API endpoints for the ESPN API.  **Note, ESPN has been known to change the URL structure without notice, so this can be a moving target.  Also, this API is not well documented, so this is not an exhaustive list of functionality; just what I have come across so far.

The root URL is
- https://lm-api-reads.fantasy.espn.com/apis/v3/games.
- A GET call to this endpoint returns basic information about the sport specific endpoints, such as the abbrevation, current season, etc.

Examples of sport specific endpoints (where {leagueId} can be replaced with your specfic league ID):
- Fantasy baseball example: https://lm-api-reads.fantasy.espn.com/apis/v3/games/flb/leagueHistory/{leagueId}
- Fantasy football example: https://lm-api-reads.fantasy.espn.com/apis/v3/games/ffl/leagueHistory/{leagueId}

To obtain year/season specific info, this URL format can be used (where {yyyy} can additionally be replaced with the four digit year for the season you wish to reference):
- https://lm-api-reads.fantasy.espn.com/apis/v3/games/flb/leagueHistory/{leagueId}?seasonId={yyyy}

Finally, to return different "views" of the data, this URL format can be used (where {viewName} can additionally be replaced by the view name):
- https://lm-api-reads.fantasy.espn.com/apis/v3/games/flb/leagueHistory/{leagueId}?seasonId={yyyy}&view={viewName}

View names I have confirmed work:
- mTeam
- mBoxscore
- mRoster
- mSettings
- kona_player_info
- player_wl
- mSchedule

## Contributing
Contributions are welcome! Please open an issue or submit a pull request.

## License
This project is licensed under the "GNU General Public License v3.0" License.  See LICENSE file for more details.
