using System.Collections.Generic;
using System.Linq;

namespace Business.DataOperations
{
    using Entities;
    using Helpers;
    public class UserData : DataOpBase
    {
        public User GetUserByID(int UserID)
        {
            User foundUser = GetActiveUsers().SingleOrDefault(q => q.ID == UserID);
            return foundUser;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            User foundUser = GetUserByUsername(username);
            if (foundUser == null)
            {
                foundUser = GetUserByEmail(username);
                if(foundUser == null)
                {
                    return null;
                }
            }

            if (foundUser.Password == EncryptionHelper.GetSHA256Hash(password))
                return foundUser;
            else
                return null;
        }

        private User GetUserByUsername(string username)
        {
            User foundUser = GetActiveUsers().SingleOrDefault(q => q.Username.ToLowerInvariant() == username.ToLowerInvariant());
            return foundUser;
        }

        private User GetUserByEmail(string email)
        {
            User foundUser = GetActiveUsers().SingleOrDefault(q => q.Email.ToLowerInvariant() == email.ToLowerInvariant());
            return foundUser;
        }

        public User CreateNewUser(string username, string email, string password)
        {
            MC_User newUser = new MC_User()
            {
                Username = username,
                Email = email,
                Password = EncryptionHelper.GetSHA256Hash(password)
            };
            dataContext.MC_Users.InsertOnSubmit(newUser);
            dataContext.SubmitChanges();
            return ToUser(newUser);
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
