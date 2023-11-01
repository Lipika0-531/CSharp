﻿using Newtonsoft.Json;
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
    public class FileManager
    {
        string filePath;
        public FileManager(string userFilePath)
        {
            filePath = userFilePath;
        }

        public string fileName(User user)
        {
            string userDetailsFile = $"{user.UserName}.json";
            return userDetailsFile;
        }
        public bool LogInDetailsToFile(string userNameLogin, string loginPassword, User user)
        {
            string userDetailsFile = fileName(user);

            if (!File.Exists(Path.Combine(filePath, userDetailsFile)))
            {
                Parser.DisplayMessages(ConsoleColor.Red, "User not found ! Try signing in or Try again !");
                return false;
            }
            else
            {
                string content = File.ReadAllText(Path.Combine(filePath, userDetailsFile), Encoding.UTF8);
                User userNew = JsonConvert.DeserializeObject<User>(content)!;
                user = userNew;
                Password password = new Password(loginPassword);

                if (user.UserName == userNameLogin && user.Password.EncodedPassword == password.EncodedPassword)
                {
                    return true;
                }
                else
                {
                    Parser.DisplayMessages(ConsoleColor.Red, "UserName and Password doesn't Match !");
                    return false;
                }
            }
        }

        public bool WriteSignInDetailsToFile(User user)
        {
            string userDetailsFile = fileName(user);

            using (FileStream writer = File.Create(Path.Combine(filePath, userDetailsFile)))
            {
                using (StreamWriter sw = new StreamWriter(writer))
                {
                    var encodedPassword = user.Password.EncodedPassword;
                    string jsonUserData = JsonConvert.SerializeObject(user);
                    sw.Write(jsonUserData);
                    return true;
                }
            }
        }

    }
}
