using Business.Helpers;
using System;

namespace Business.Entities
{
    public class CountdownStructure
    {
        public CountdownStructure()
        {
            remainingTime = new RemainingTime();
            Title = string.Empty;
            SetEndTimeUtc(DateTime.UtcNow);
            IsInProgress = false;
            IsDeleted = false;
            UpdateTimeUtc = DateTime.UtcNow;
        }
        public CountdownStructure(string title, double totalSeconds)
            : this()
        {
            Title = title;
            SetTotalSeconds(totalSeconds);
        }
        public CountdownStructure(string title, DateTime endTimeUtc)
            : this()
        {
            Title = title;
            SetEndTimeUtc(endTimeUtc);
        }

        #region database properties
        public long ID { get; set; }

        public int UserID { get; set; }

        //nvarchar(150)
        public string Title { get; set; }

        public string CountdownGuid { get; set; }

        public DateTime EndTimeUtc { get; private set; }
        public void SetEndTimeUtc(DateTime endTimeUtc)
        {
            EndTimeUtc = endTimeUtc;
            TotalSeconds = Math.Floor((double)(EndTimeUtc - DateTime.UtcNow).TotalSeconds);
            remainingTime.TickingSeconds = TotalSeconds;
        }
        
        public bool IsInProgress { get; set; }
        
        public bool IsDeleted { get; set; }

        public DateTime UpdateTimeUtc { get; set; }
        #endregion database properties
        
        public double TotalSeconds { get; private set; }
        public void SetTotalSeconds(double totalSeconds)
        {
            TotalSeconds = remainingTime.TickingSeconds = totalSeconds;
            EndTimeUtc = DateTime.UtcNow.AddSeconds(TotalSeconds);
        }

        public EqualityStatus Compare(CountdownStructure other)
        {
            EndTimeUtc = EndTimeUtc.ToDateTimeWithoutMilliseconds();
            other.EndTimeUtc = other.EndTimeUtc.ToDateTimeWithoutMilliseconds();
            UpdateTimeUtc = UpdateTimeUtc.ToDateTimeWithoutMilliseconds();
            other.UpdateTimeUtc = other.UpdateTimeUtc.ToDateTimeWithoutMilliseconds();

            if (other == null || CountdownGuid != other.CountdownGuid)
            {
                return EqualityStatus.CompletelyDifferent;
            }
            else if (IsInProgress == other.IsInProgress && IsDeleted == other.IsDeleted && EndTimeUtc == other.EndTimeUtc)
            {
                return EqualityStatus.Equal;
            }
            else
            {
                if (UpdateTimeUtc > other.UpdateTimeUtc)
                {
                    return EqualityStatus.FirstIsNew;
                }
                else if (other.UpdateTimeUtc > UpdateTimeUtc)
                {
                    return EqualityStatus.SecondIsNew;
                }
                else
                {
                    return EqualityStatus.Equal;
                }
            }
        }

        public RemainingTime remainingTime;
        public class RemainingTime
        {
            public double TickingSeconds { get; set; }
            public double Days { get { return Math.Floor(TickingSeconds / 86400); } }
            public double Hours { get { return Math.Floor((TickingSeconds - (Days * 86400)) / 3600); } }
            public double Minutes { get { return Math.Floor((TickingSeconds - (Days * 86400) - (Hours * 3600)) / 60); } }
            public double Seconds { get { return TickingSeconds - (Days * 86400) - (Hours * 3600) - (Minutes * 60); } }
        }

        public enum EqualityStatus
        {
            CompletelyDifferent,
            Equal,
            FirstIsNew,
            SecondIsNew
        }
    }
}
