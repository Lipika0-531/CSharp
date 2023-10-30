using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MoneyManager
{
    /// <summary>
    /// Adding and Reading Files.
    /// </summary>
    internal class FileManager
    {
        private string userDetailsFile = "UserDetails.json";
        public void WriteUserDetailsToFile(User user)
        {
            using (StreamWriter writer = File.AppendText(userDetailsFile))
            {
                var encodedPassword = user.Password.EncodePassword;
                writer.WriteLine($"{user.UserName},{encodedPassword} ");
                JsonConvert.SerializeObject(encodedPassword, writer );
            }
        }

    }
}
