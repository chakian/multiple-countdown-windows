using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Extensions
{
    public static class CountdownStructureExtension
    {
        public static List<CountdownStructure> GetOnlyOngoingActiveCountdowns(this List<CountdownStructure> list)
        {
            return list.Where(q => q.IsDeleted == false && q.EndTimeUtc >= DateTime.UtcNow).ToList();
        }

        public static CountdownStructure ToStructure(this MC_Countdown input)
        {
            CountdownStructure output = new CountdownStructure(input.Title, input.EndTimeUtc)
            {
                ID = input.ID,
                UserID = input.UserID,
                CountdownGuid = input.CountdownGuid,
                IsInProgress = input.IsInProgress,
                IsDeleted = input.IsDeleted,
                UpdateTimeUtc = input.UpdateTimeUtc
            };
            return output;
        }

        public static MC_Countdown ToDataObject(this CountdownStructure input)
        {
            MC_Countdown output = new MC_Countdown()
            {
                ID = input.ID,
                UserID = input.UserID,
                CountdownGuid = input.CountdownGuid,
                Title = input.Title,
                EndTimeUtc = input.EndTimeUtc,
                IsInProgress = input.IsInProgress,
                IsDeleted = input.IsDeleted,
                UpdateTimeUtc = input.UpdateTimeUtc
            };
            return output;
        }
    }
}
