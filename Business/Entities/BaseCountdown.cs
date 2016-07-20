//using System;

//namespace MultipleCountdown
//{
//    public class BaseCountdownStructure
//    {
//        private decimal _totalSeconds;

//        public string Title { get; set; }
//        public decimal TotalSeconds { get { return _totalSeconds; } set { _totalSeconds = TickingSeconds = value; } }

//        public bool IsTicking { get; set; }
//        public decimal TickingSeconds { get; set; }
//        public decimal Days { get { return Math.Floor(TickingSeconds / 86400); } }
//        public decimal Hours { get { return Math.Floor((TickingSeconds - (Days * 86400)) / 3600); } }
//        public decimal Minutes { get { return Math.Floor((TickingSeconds - (Days * 86400) - (Hours * 3600)) / 60); } }
//        public decimal Seconds { get { return TickingSeconds - (Days * 86400) - (Hours * 3600) - (Minutes * 60); } }
//    }
//}