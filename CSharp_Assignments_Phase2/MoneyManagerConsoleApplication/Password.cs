using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerConsoleApplication
{
    internal class Password
    {
        public Password(string value)
        {
            this.EncodedPassword= EncodePassword(value);
        }

        private string EncodedPassword { get; set; }


        public string EncodePassword(string value)
        {
            byte[] bytes = new byte[value.Length];
            bytes = Encoding.UTF8.GetBytes(value);
            var encodedPassword = Convert.ToBase64String(bytes, 0, bytes.Length);
            return encodedPassword;
        }

        public void Decodepassword(string value)
        {
            byte[] secret = Convert.FromBase64String(value);
            byte[] plain = ProtectedData.Unprotect(secret, null, DataProtectionScope.CurrentUser);
            var encoding = new UTF8Encoding();
            var decodedPassword = encoding.GetString(plain);
        }

        public bool PasswordChecker(string password)
        {
            var encodedPassword = EncodePassword(password);
            return (encodedPassword == this.EncodedPassword);
        }
    }
}
