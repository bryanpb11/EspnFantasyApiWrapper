using System.Text.Json.Serialization;

namespace EspnFantasyApiWrapper.API.Model.EspnRoster
{
    public class Roster
    {
        [JsonPropertyName("draftDetail")]
        public DraftDetail? DraftDetail { get; set; }

        [JsonPropertyName("gameId")]
        public int GameId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("scoringPeriodId")]
        public int ScoringPeriodId { get; set; }

        [JsonPropertyName("seasonId")]
        public int SeasonId { get; set; }

        [JsonPropertyName("segmentId")]
        public int SegmentId { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; } = new();

        [JsonPropertyName("teams")]
        public List<TeamData> Teams { get; set; } = [];
    }

    public class DraftDetail
    {
        [JsonPropertyName("drafted")]
        public bool Drafted { get; set; }

        [JsonPropertyName("inProgress")]
        public bool InProgress { get; set; }
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

    public class TeamData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("roster")]
        public RosterDetail Roster { get; set; } = new();
    }

    public class RosterDetail
    {
        [JsonPropertyName("appliedStatTotal")]
        public double AppliedStatTotal { get; set; }

        [JsonPropertyName("entries")]
        public List<Entry> Entries { get; set; } = [];
    }

    public class Entry
    {
        [JsonPropertyName("acquisitionDate")]
        public object AcquisitionDate { get; set; } = new();

        [JsonPropertyName("acquisitionType")]
        public object AcquisitionType { get; set; } = new();

        [JsonPropertyName("injuryStatus")]
        public string InjuryStatus { get; set; } = "";

        [JsonPropertyName("lineupSlotId")]
        public int LineupSlotId { get; set; }

        [JsonPropertyName("pendingTransactionIds")]
        public object PendingTransactionIds { get; set; } = new();

        [JsonPropertyName("playerId")]
        public int PlayerId { get; set; }

        [JsonPropertyName("playerPoolEntry")]
        public PlayerPoolEntry PlayerPoolEntry { get; set; } = new();

        [JsonPropertyName("status")]
        public string Status { get; set; } = "";
    }

    public class PlayerPoolEntry
    {
        [JsonPropertyName("appliedStatTotal")]
        public double AppliedStatTotal { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("keeperValue")]
        public int KeeperValue { get; set; }

        [JsonPropertyName("keeperValueFuture")]
        public int KeeperValueFuture { get; set; }

        [JsonPropertyName("lineupLocked")]
        public bool LineupLocked { get; set; }

        [JsonPropertyName("onTeamId")]
        public int OnTeamId { get; set; }

        [JsonPropertyName("player")]
        public Player Player { get; set; } = new();

        [JsonPropertyName("ratings")]
        public Ratings Ratings { get; set; } = new();

        [JsonPropertyName("rosterLocked")]
        public bool RosterLocked { get; set; }

        [JsonPropertyName("tradeLocked")]
        public bool TradeLocked { get; set; }
    }

    public class Player
    {
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("defaultPositionId")]
        public int DefaultPositionId { get; set; }

        [JsonPropertyName("draftRanksByRankType")]
        public Dictionary<string, DraftRank> DraftRanksByRankType { get; set; } = [];

        [JsonPropertyName("droppable")]
        public bool Droppable { get; set; }

        [JsonPropertyName("eligibleSlots")]
        public List<int> EligibleSlots { get; set; } = [];

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = "";

        [JsonPropertyName("fullName")]
        public string FullName { get; set; } = "";

        [JsonPropertyName("gamesPlayedByPosition")]
        public Dictionary<string, int> GamesPlayedByPosition { get; set; } = [];

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("injured")]
        public bool Injured { get; set; }

        [JsonPropertyName("injuryStatus")]
        public string InjuryStatus { get; set; } = "";

        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = "";

        [JsonPropertyName("ownership")]
        public Ownership Ownership { get; set; } = new();

        [JsonPropertyName("proTeamId")]
        public int ProTeamId { get; set; }

        [JsonPropertyName("stats")]
        public List<Stat> Stats { get; set; } = [];

        [JsonPropertyName("universeId")]
        public int UniverseId { get; set; }
    }

    public class DraftRank
    {
        [JsonPropertyName("auctionValue")]
        public int AuctionValue { get; set; }

        [JsonPropertyName("published")]
        public bool Published { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("rankSourceId")]
        public int RankSourceId { get; set; }

        [JsonPropertyName("rankType")]
        public string RankType { get; set; } = "";

        [JsonPropertyName("slotId")]
        public int SlotId { get; set; }
    }

    public class Ownership
    {
        [JsonPropertyName("auctionValueAverage")]
        public double AuctionValueAverage { get; set; }

        [JsonPropertyName("averageDraftPosition")]
        public double AverageDraftPosition { get; set; }

        [JsonPropertyName("percentChange")]
        public double PercentChange { get; set; }

        [JsonPropertyName("percentOwned")]
        public double PercentOwned { get; set; }

        [JsonPropertyName("percentStarted")]
        public double PercentStarted { get; set; }
    }

    public class Stat
    {
        [JsonPropertyName("appliedAverage")]
        public double AppliedAverage { get; set; }

        [JsonPropertyName("appliedStats")]
        public Dictionary<string, decimal> AppliedStats { get; set; } = [];

        [JsonPropertyName("appliedTotal")]
        public double AppliedTotal { get; set; }

        [JsonPropertyName("externalId")]
        public string ExternalId { get; set; } = "";

        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("proTeamId")]
        public int ProTeamId { get; set; }

        [JsonPropertyName("scoringPeriodId")]
        public int ScoringPeriodId { get; set; }

        [JsonPropertyName("seasonId")]
        public int SeasonId { get; set; }

        [JsonPropertyName("statSourceId")]
        public int StatSourceId { get; set; }

        [JsonPropertyName("statSplitTypeId")]
        public int StatSplitTypeId { get; set; }

        [JsonPropertyName("stats")]
        public Dictionary<string, object> Stats { get; set; } = [];
    }

    public class Ratings
    {
        [JsonPropertyName("positionalRanking")]
        public Dictionary<string, Rating> PositionalRanking { get; set; } = [];

        [JsonPropertyName("totalRanking")]
        public Dictionary<string, Rating> TotalRanking { get; set; } = [];

        [JsonPropertyName("totalRating")]
        public Dictionary<string, Rating> TotalRating { get; set; } = [];
    }

    public class Rating
    {
        [JsonPropertyName("positionalRanking")]
        public int PositionalRanking { get; set; }

        [JsonPropertyName("totalRanking")]
        public int TotalRanking { get; set; }

        [JsonPropertyName("totalRating")]
        public double TotalRating { get; set; }
    }
}
