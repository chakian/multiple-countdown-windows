using System.Collections.Generic;
using System.Linq;

namespace Business.DataOperations
{
    using Entities;
    using Helpers;

    public class CountdownData : DataOpBase
    {
        public List<Countdown> GetCountdownsOfUser(int userID)
        {
            List<Countdown> result = new List<Countdown>();
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

        private Countdown ToCountdown(MC_Countdown input)
        {
            Countdown output = new Countdown()
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

        private MC_Countdown FromCountdown(Countdown input)
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
