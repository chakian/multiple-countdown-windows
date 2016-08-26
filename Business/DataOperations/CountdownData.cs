using System.Collections.Generic;
using System.Linq;

namespace Business.DataOperations
{
    using Entities;
    using Extensions;
    using System;
    public class CountdownData : DataOpBase
    {
        #region Insert - Update - Delete
        public CountdownStructure InsertCountdown(CountdownStructure cStruct)
        {
            MC_Countdown countdown = cStruct.ToDataObject();
            countdown.UpdateTimeUtc = DateTime.UtcNow;
            dataContext.MC_Countdowns.InsertOnSubmit(countdown);
            dataContext.SubmitChanges();
            return countdown.ToStructure();
        }
        public void UpdateCountdown(CountdownStructure cStruct)
        {
            MC_Countdown countdown = GetCountdownByUniqueInfo(cStruct.UserID, cStruct.Title, cStruct.CountdownGuid);
            if(countdown != null)
            {
                countdown.IsInProgress = cStruct.IsInProgress;
                countdown.IsDeleted= cStruct.IsDeleted;
                countdown.EndTimeUtc = cStruct.EndTimeUtc;

                UpdateCountdown(countdown);
            }
        }
        private void UpdateCountdown(MC_Countdown countdown)
        {
            countdown.UpdateTimeUtc = DateTime.UtcNow;
            dataContext.SubmitChanges();
        }
        public void DeleteCountdown(CountdownStructure cStruct)
        {
            MC_Countdown countdown = GetCountdownByUniqueInfo(cStruct.UserID, cStruct.Title, cStruct.CountdownGuid);
            if (countdown != null)
            {
                countdown.IsDeleted = true;
                UpdateCountdown(countdown);
            }
        }
        #endregion Insert - Update - Delete

        public List<CountdownStructure> GetAllCountdownsOfUser(int userID)
        {
            List<CountdownStructure> result = new List<CountdownStructure>();
            var countdowns = GetAllCountdowns().Where(q => q.UserID == userID).ToList();
            foreach (var item in countdowns)
            {
                result.Add(item.ToStructure());
            }
            return result;
        }

        public List<CountdownStructure> GetNotDeletedCountdownsOfUser(int userID)
        {
            var countdowns = GetAllCountdownsOfUser(userID).Where(q => q.IsDeleted == false).ToList();
            return countdowns;
        }

        public List<CountdownStructure> GetOngoingCountdownsOfUser(int userID)
        {
            var countdowns = GetNotDeletedCountdownsOfUser(userID).Where(q => q.EndTimeUtc >= DateTime.UtcNow).ToList();
            return countdowns;
        }
        
        private MC_Countdown GetCountdownByUniqueInfo(int userID, string title, string guid)
        {
            var countdown = GetAllCountdowns().SingleOrDefault(q => q.UserID == userID && q.Title == title && q.CountdownGuid == guid);
            return countdown;
        }

        private IEnumerable<MC_Countdown> GetAllCountdowns()
        {
            return dataContext.MC_Countdowns.AsEnumerable();
        }
    }
}
