namespace EspnFantasyApiWrapper.API.Model
{
    /// <summary>
    /// Simplified TeamStats object with only some of the data fields from the ESPN API
    /// </summary>
    public class TeamStats
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string PrimaryOwnerId { get; set; } = string.Empty;
        public string PrimaryOwnerFirstName { get; set; } = string.Empty;
        public string PrimaryOwnerLastName { get; set; } = string.Empty;
        public int PlayoffSeed { get; set; }
        public decimal Points { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
