using EvxWebAppCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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
        public static void SessionSet<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T SessionGet<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
        public static List<SelectListItem> GenerateSelectListForLines(List<LineModel> Lines, DeviceModelPHP devicePHP)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (LineModel entry in Lines)
            {
                result.Add(new SelectListItem
                {
                    Text = entry.LineName,
                    Value = entry.LineID.ToString(),
                    Selected = entry.LineID == devicePHP.tblLineID
                });
            }
            return result;
        }
        public static List<SelectListItem> GenerateSelectListForDrivers(List<UserDetailModel> Lines)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (UserDetailModel entry in Lines)
            {
                result.Add(new SelectListItem
                {
                    Text = entry.username,
                    Value = entry.ID.ToString(),
                    Selected = false
                });
            }
            return result;
        }


    }
}
