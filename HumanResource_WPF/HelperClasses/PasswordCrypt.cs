using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HumanResource_WPF
{
    class PasswordCrypt
    {
        public static string SimpleEncrypt(string password)
        {
            byte[] clear = Encoding.ASCII.GetBytes(password);
            HashAlgorithm sha2 = SHA256CryptoServiceProvider.Create();
            byte[] hashed = sha2.ComputeHash(clear);
            return Convert.ToBase64String(hashed);
        }
    }
}

