using System.Collections.Generic;
using System.Linq;

namespace Business.DataOperations
{
    using Entities;
    using Helpers;

    public class CountdownData : DataOpBase
    {
        public CountdownStructure InsertCountdown(CountdownStructure countdown)
        {
            MC_Countdown newCountdown = FromCountdown(countdown);
            dataContext.MC_Countdowns.InsertOnSubmit(newCountdown);
            dataContext.SubmitChanges();
            return ToCountdown(newCountdown);
        }

        public List<CountdownStructure> GetCountdownsOfUser(int userID)
        {
            List<CountdownStructure> result = new List<CountdownStructure>();
            foreach (var item in GetActiveCountdowns())
            {
                result.Add(ToCountdown(item));
            }
            return result;
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
            CountdownStructure output = new CountdownStructure()
            {
                ID = input.ID,
                UserID = input.UserID,
                Title = input.Title,
                EndTime = input.EndTime,
                IsInProgress = input.IsInProgress,
                CreateTime = input.CreateTime,
                UpdateTime = input.UpdateTime,
                IsDeleted = input.IsDeleted,
                EndTimeUTC = input.EndTimeUTC
            };
            return output;
        }

        private MC_Countdown FromCountdown(CountdownStructure input)
        {
            MC_Countdown output = new MC_Countdown()
            {
                ID = input.ID,
                UserID = input.UserID,
                Title = input.Title,
                EndTime = input.EndTime,
                IsInProgress = input.IsInProgress,
                CreateTime = input.CreateTime,
                UpdateTime = input.UpdateTime,
                IsDeleted = input.IsDeleted,
                EndTimeUTC = input.EndTimeUTC
            };
            return output;
        }
    }
}
