﻿using System.Collections.Generic;
using System.Linq;

namespace Business.DataOperations
{
    using Entities;
    using Helpers;
    using System;
    public class CountdownData : DataOpBase
    {
        public CountdownStructure InsertCountdown(CountdownStructure countdown)
        {
            MC_Countdown newCountdown = FromCountdown(countdown);
            dataContext.MC_Countdowns.InsertOnSubmit(newCountdown);
            dataContext.SubmitChanges();
            return ToCountdown(newCountdown);
        }
        public void UpdateCountdown(CountdownStructure countdown)
        {
            MC_Countdown newCountdown = GetCountdownByUniqueInfo(countdown.UserID, countdown.Title, countdown.CountdownGuid);
            if(newCountdown != null)
            {
                newCountdown.IsInProgress = countdown.IsInProgress;
                newCountdown.IsDeleted= countdown.IsDeleted;
                newCountdown.EndTimeUtc = countdown.EndTimeUtc;
                dataContext.SubmitChanges();
            }
        }
        public void DeleteCountdown(CountdownStructure cd)
        {
            MC_Countdown countdown = GetCountdownByUniqueInfo(cd.UserID, cd.Title, cd.CountdownGuid);
            if (countdown != null)
            {
                dataContext.MC_Countdowns.DeleteOnSubmit(countdown);
                dataContext.SubmitChanges();
            }
        }

        //private CountdownStructure GetCountdownByUniqueInfo(int userID, string title, string guid)
        //{
        //    var countdown = GetCountdownsOfUser(userID).SingleOrDefault(q => q.Title == title && q.CountdownGuid == guid);
        //    return countdown;
        //}

        public List<CountdownStructure> GetCountdownsOfUser(int userID)
        {
            List<CountdownStructure> result = new List<CountdownStructure>();
            foreach (var item in GetOngoingCountdowns())
            {
                result.Add(ToCountdown(item));
            }
            return result;
        }

        private MC_Countdown GetCountdownByUniqueInfo(int userID, string title, string guid)
        {
            var countdown = GetOngoingCountdowns().SingleOrDefault(q => q.UserID == userID && q.Title == title && q.CountdownGuid == guid);
            return countdown;
        }

        private IEnumerable<MC_Countdown> GetOngoingCountdowns()
        {
            var ongoingCountdowns = GetActiveCountdowns().Where(q => q.EndTimeUtc > DateTime.UtcNow);
            return ongoingCountdowns;
        }
        private IEnumerable<MC_Countdown> GetOldCountdowns()
        {
            var oldCountdowns = GetActiveCountdowns().Where(q => q.EndTimeUtc <= DateTime.UtcNow);
            return oldCountdowns;
        }

        private IEnumerable<MC_Countdown> GetActiveCountdowns()
        {
            var activeCountdowns = GetAllCountdowns().Where(q=>q.IsDeleted == false);
            return activeCountdowns;
        }

        private IEnumerable<MC_Countdown> GetAllCountdowns()
        {
            return dataContext.MC_Countdowns.AsEnumerable();
        }

        private CountdownStructure ToCountdown(MC_Countdown input)
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

        private MC_Countdown FromCountdown(CountdownStructure input)
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
