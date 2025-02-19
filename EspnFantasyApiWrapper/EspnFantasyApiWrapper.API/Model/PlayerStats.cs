namespace EspnFantasyApiWrapper.API.Model
{
    public class PlayerStats
    {
        public int TeamId { get; set; }
        public string Year { get; set; } = "";
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = "";
        public int DefaultPositionId { get; set; }
        public int LineupSlotId { get; set; }
        public decimal StatsAppliedTotal { get; set; }
        public decimal StatsAppliedAverage { get; set; }
        
    }
}
