using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ExpenseTrackerConsoleApplication
{
    /// <summary>
    /// Adding and Reading Files.
    /// </summary>
    internal class FileManager
    {
        public void WriteUserDetailsToFile(User user)
        {
            string userDetailsFile = $"{user.UserName}.json";

            using (FileStream writer = File.Create(userDetailsFile))
            {
                using (StreamWriter sw = new StreamWriter(writer))
                {
                    var encodedPassword = user.Password.EncodedPassword;
                    string jsonUserData = JsonConvert.SerializeObject(user);
                    sw.Write(jsonUserData);
                }
            }
        }

    }
}
