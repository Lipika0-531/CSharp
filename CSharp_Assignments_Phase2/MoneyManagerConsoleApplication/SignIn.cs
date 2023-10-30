using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerConsoleApplication
{
    internal class SignIn
    {        
        Parser parser = new Parser();
        public static Dictionary<string, User> users = new Dictionary<string, User>();
        public User UserSignIn(string userName, string password)
        {
            var addUser = new User(userName, password);
            ActiveUsers.ActiveUsersList.Add(addUser);
            users[userName] = addUser;
            return addUser;
        }

        public string CheckIfUserNameUnique(string userName)
        {
            while (users.ContainsKey(userName))
            {
                userName = parser.ValidateInputs<string>("UserName already taken, Enter valid UserName : ");
            }
            return userName;
        }
    }
}
