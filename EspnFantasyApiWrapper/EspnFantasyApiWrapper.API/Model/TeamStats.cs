namespace EspnFantasyApiWrapper.API.Model
{
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
