using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Core.V1
{
    public class EncryptCore
    {
        public EncryptCore() { }
        public static string Encrypt_SHA256(string value, string key)
        {
            string text = $"{key}//{value}//{key}";
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            StringBuilder sb = new StringBuilder();
            byte[] stream = null;
            stream = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
