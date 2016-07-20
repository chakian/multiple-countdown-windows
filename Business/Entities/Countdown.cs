using System;

namespace Business.Entities
{
    public class CountdownStructure
    {
        #region database properties
        public long ID { get; set; }

        public int UserID { get; set; }

        //nvarchar(150)
        public string Title { get; set; }
        
        public DateTime EndTime { get; set; }
        
        public DateTime CreateTime { get; set; }
        
        public DateTime UpdateTime { get; set; }
        
        public bool IsInProgress { get; set; }
        
        public bool IsDeleted { get; set; }

        private DateTime _endTimeUTC;
        public DateTime EndTimeUTC { get { return _endTimeUTC; } set { _endTimeUTC = value; TotalSeconds = (decimal)(EndTimeUTC - DateTime.UtcNow).TotalSeconds; } }
        #endregion database properties

        private decimal _totalSeconds;
        
        public decimal TotalSeconds { get { return _totalSeconds; } set { _totalSeconds = TickingSeconds = value; } }

        public bool IsTicking { get; set; }
        public decimal TickingSeconds { get; set; }
        public decimal Days { get { return Math.Floor(TickingSeconds / 86400); } }
        public decimal Hours { get { return Math.Floor((TickingSeconds - (Days * 86400)) / 3600); } }
        public decimal Minutes { get { return Math.Floor((TickingSeconds - (Days * 86400) - (Hours * 3600)) / 60); } }
        public decimal Seconds { get { return TickingSeconds - (Days * 86400) - (Hours * 3600) - (Minutes * 60); } }
    }
}
