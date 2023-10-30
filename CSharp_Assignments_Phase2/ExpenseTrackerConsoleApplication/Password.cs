using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerConsoleApplication
{
    /// <summary>
    /// Encode and Decode Password.
    /// </summary>
    internal class Password
    {
        /// <summary>
        /// EncodedPassword.
        /// </summary>
        /// <param name="value">Value</param>
        public Password(string value)
        {
            this.EncodedPassword = EncodePassword(value);
        }

        public string EncodedPassword { get; set; }


        /// <summary>
        /// Encode Password.
        /// </summary>
        /// <param name="value">password</param>
        /// <returns>encoded password</returns>
        public string EncodePassword(string value)
        {
            byte[] bytes = new byte[value.Length];
            bytes = Encoding.UTF8.GetBytes(value);
            var encodedPassword = Convert.ToBase64String(bytes, 0, bytes.Length);
            return encodedPassword;
        }

        /// <summary>
        /// Decode Password.
        /// </summary>
        /// <param name="value">password</param>
        public void Decodepassword(string value)
        {
            byte[] secret = Convert.FromBase64String(value);
            byte[] plain = ProtectedData.Unprotect(secret, null, DataProtectionScope.CurrentUser);
            var encoding = new UTF8Encoding();
            var decodedPassword = encoding.GetString(plain);
        }

        /// <summary>
        /// Check password with encodedPassword.
        /// </summary>
        /// <param name="password">Password</param>
        /// <returns>bool</returns>
        public bool PasswordChecker(string password)
        {
            var encodedPassword = EncodePassword(password);
            return (encodedPassword == this.EncodedPassword);
        }
    }
}
