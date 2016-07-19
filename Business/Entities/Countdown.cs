using System;

namespace Business.Entities
{
    public class Countdown
    {
        public long ID { get; set; }

        public int UserID { get; set; }

        //nvarchar(150)
        public string Title { get; set; }
        
        public DateTime EndTime { get; set; }
        
        public DateTime CreateTime { get; set; }
        
        public DateTime UpdateTime { get; set; }
        
        public bool IsInProgress { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
