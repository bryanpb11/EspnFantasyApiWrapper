using System.Text.Json.Serialization;

namespace EspnFantasyApiWrapper.API.Model.EspnTeam
{
    public class TeamData
    {
        [JsonPropertyName("draftDetail")]
        public DraftDetail DraftDetail { get; set; } = new();

        [JsonPropertyName("gameId")]
        public int GameId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("members")]
        public List<Member> Members { get; set; } = [];

        [JsonPropertyName("scoringPeriodId")]
        public int ScoringPeriodId { get; set; }

        [JsonPropertyName("seasonId")]
        public int SeasonId { get; set; }

        [JsonPropertyName("segmentId")]
        public int SegmentId { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; } = new();

        [JsonPropertyName("teams")]
        public List<Team> Teams { get; set; } = [];
    }

    public class DraftDetail
    {
        [JsonPropertyName("drafted")]
        public bool Drafted { get; set; }

        [JsonPropertyName("inProgress")]
        public bool InProgress { get; set; }
    }

    public class Member
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; } = "";

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = "";

        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = "";
    }

    public class Status
    {
        [JsonPropertyName("activatedDate")]
        public long ActivatedDate { get; set; }

        [JsonPropertyName("createdAsLeagueType")]
        public int CreatedAsLeagueType { get; set; }

        [JsonPropertyName("currentLeagueType")]
        public int CurrentLeagueType { get; set; }

        [JsonPropertyName("currentMatchupPeriod")]
        public int CurrentMatchupPeriod { get; set; }

        [JsonPropertyName("finalScoringPeriod")]
        public int FinalScoringPeriod { get; set; }

        [JsonPropertyName("firstScoringPeriod")]
        public int FirstScoringPeriod { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("isExpired")]
        public bool IsExpired { get; set; }

        [JsonPropertyName("isFull")]
        public bool IsFull { get; set; }

        [JsonPropertyName("isPlayoffMatchupEdited")]
        public bool IsPlayoffMatchupEdited { get; set; }

        [JsonPropertyName("isToBeDeleted")]
        public bool IsToBeDeleted { get; set; }

        [JsonPropertyName("isViewable")]
        public bool IsViewable { get; set; }

        [JsonPropertyName("isWaiverOrderEdited")]
        public bool IsWaiverOrderEdited { get; set; }

        [JsonPropertyName("latestScoringPeriod")]
        public int LatestScoringPeriod { get; set; }

        [JsonPropertyName("previousSeasons")]
        public List<int> PreviousSeasons { get; set; } = [];

        [JsonPropertyName("standingsUpdateDate")]
        public long StandingsUpdateDate { get; set; }

        [JsonPropertyName("teamsJoined")]
        public int TeamsJoined { get; set; }

        [JsonPropertyName("transactionScoringPeriod")]
        public int TransactionScoringPeriod { get; set; }

        [JsonPropertyName("waiverLastExecutionDate")]
        public long WaiverLastExecutionDate { get; set; }

        [JsonPropertyName("waiverNextExecutionDate")]
        public long WaiverNextExecutionDate { get; set; }

        [JsonPropertyName("waiverProcessStatus")]
        public Dictionary<string, int> WaiverProcessStatus { get; set; } = [];
    }

    public class Team
    {
        [JsonPropertyName("abbrev")]
        public string Abbrev { get; set; } = "";

        [JsonPropertyName("currentProjectedRank")]
        public int CurrentProjectedRank { get; set; }

        [JsonPropertyName("divisionId")]
        public int DivisionId { get; set; }

        [JsonPropertyName("draftDayProjectedRank")]
        public int DraftDayProjectedRank { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("logo")]
        public string Logo { get; set; } = "";

        [JsonPropertyName("logoType")]
        public string LogoType { get; set; } = "";

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("owners")]
        public List<string> Owners { get; set; } = [];

        [JsonPropertyName("playoffSeed")]
        public int PlayoffSeed { get; set; }

        [JsonPropertyName("points")]
        public double Points { get; set; }

        [JsonPropertyName("pointsAdjusted")]
        public double PointsAdjusted { get; set; }

        [JsonPropertyName("pointsDelta")]
        public double PointsDelta { get; set; }

        [JsonPropertyName("primaryOwner")]
        public string PrimaryOwner { get; set; } = "";

        [JsonPropertyName("rankCalculatedFinal")]
        public int RankCalculatedFinal { get; set; }

        [JsonPropertyName("rankFinal")]
        public int RankFinal { get; set; }

        [JsonPropertyName("record")]
        public Record Record { get; set; } = new();

        [JsonPropertyName("transactionCounter")]
        public TransactionCounter TransactionCounter { get; set; } = new();

        [JsonPropertyName("valuesByStat")]
        public Dictionary<string, double> ValuesByStat { get; set; } = [];

        [JsonPropertyName("waiverRank")]
        public int WaiverRank { get; set; }

        [JsonPropertyName("watchList")]
        public List<int> WatchList { get; set; } = [];
    }

    public class Record
    {
        [JsonPropertyName("away")]
        public RecordDetail Away { get; set; } = new();

        [JsonPropertyName("division")]
        public RecordDetail Division { get; set; } = new();

        [JsonPropertyName("home")]
        public RecordDetail Home { get; set; } = new();

        [JsonPropertyName("overall")]
        public RecordDetail Overall { get; set; } = new();
    }

    public class RecordDetail
    {
        [JsonPropertyName("gamesBack")]
        public double GamesBack { get; set; }

        [JsonPropertyName("losses")]
        public int Losses { get; set; }

        [JsonPropertyName("percentage")]
        public double Percentage { get; set; }

        [JsonPropertyName("pointsAgainst")]
        public double PointsAgainst { get; set; }

        [JsonPropertyName("pointsFor")]
        public double PointsFor { get; set; }

        [JsonPropertyName("streakLength")]
        public int StreakLength { get; set; }

        [JsonPropertyName("streakType")]
        public string StreakType { get; set; } = "";

        [JsonPropertyName("ties")]
        public int Ties { get; set; }

        [JsonPropertyName("wins")]
        public int Wins { get; set; }
    }

    public class TransactionCounter
    {
        [JsonPropertyName("acquisitionBudgetSpent")]
        public int AcquisitionBudgetSpent { get; set; }

        [JsonPropertyName("acquisitions")]
        public int Acquisitions { get; set; }

        [JsonPropertyName("drops")]
        public int Drops { get; set; }

        [JsonPropertyName("matchupAcquisitionTotals")]
        public Dictionary<string, int> MatchupAcquisitionTotals { get; set; } = [];

        [JsonPropertyName("misc")]
        public int Misc { get; set; }

        [JsonPropertyName("moveToActive")]
        public int MoveToActive { get; set; }

        [JsonPropertyName("moveToIR")]
        public int MoveToIR { get; set; }

        [JsonPropertyName("paid")]
        public double Paid { get; set; }

        [JsonPropertyName("teamCharges")]
        public double TeamCharges { get; set; }

        [JsonPropertyName("trades")]
        public int Trades { get; set; }
    }
}
