using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EvxWebAppCore.Common
{
    public static class GlobalHelpers
    {
        //Code from: https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?redirectedfrom=MSDN&view=netframework-4.8
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        //Code from: https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?redirectedfrom=MSDN&view=netframework-4.8
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return 0 == comparer.Compare(GetMd5Hash(md5Hash, input), hash);
        }

    }
}
