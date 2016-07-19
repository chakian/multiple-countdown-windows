using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.DataOperations
{
    using Entities;

    public class UserData : DataOpBase
    {
        public User GetUserByID(int UserID)
        {
            User foundUser = GetActiveUsers().SingleOrDefault(q => q.ID == UserID);
            return foundUser;
        }
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            User foundUser = GetActiveUsers().SingleOrDefault(q => q.Username == username && q.Password == password);
            return foundUser;
        }

        private List<User> GetActiveUsers()
        {
            var allUsers = GetAllUsers();
            //TODO: Do the filtering here
            //allusers.where(q=>q.blabla)...
            var activeUsers = allUsers;
            return activeUsers;
        }
        private List<User> GetAllUsers()
        {
            List<User> result = new List<User>();
            foreach (var item in dataContext.MC_Users.ToList())
            {
                result.Add(ToUser(item));
            }
            return result;
        }

        private User ToUser(MC_User input)
        {
            User output = new User();
            output.ID = input.ID;
            output.Username = input.Username;
            output.Password = input.Password;
            output.Email = input.Email;
            return output;
        }
        private MC_User FromUser(User input)
        {
            MC_User output = new MC_User();
            output.ID = input.ID;
            output.Username = input.Username;
            output.Password = input.Password;
            output.Email = input.Email;
            return output;
        }
    }
}
