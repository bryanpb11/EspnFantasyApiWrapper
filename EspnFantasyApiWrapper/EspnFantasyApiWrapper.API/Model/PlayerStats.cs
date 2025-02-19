namespace EspnFantasyApiWrapper.API.Model
{
    /// <summary>
    /// Simplified PlayerStats object with only some of the data fields from the ESPN API
    /// </summary>
    public class PlayerStats
    {
        public int TeamId { get; set; }
        public string Year { get; set; } = "";
        public int PlayerId { get; set; } = 0;
        public string PlayerName { get; set; } = "";
        public int DefaultPositionId { get; set; }
        public int LineupSlotId { get; set; }
        public decimal StatsAppliedTotal { get; set; }
        public decimal StatsAppliedAverage { get; set; }
        
    }
}
