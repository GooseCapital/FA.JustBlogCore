using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace FA.JustBlogCore.Services.Utilities
{
    public static class Utilities
    {
        public static string GenerateSlug(this string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            temp = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').Trim().Replace(" ", "-").ToLower();
            return Regex.Replace(temp, @"[^a-z0-9\s-]", "");
        }

        public static string GenerateSlugNotDuplicate(this string s, List<string> currentSlug)
        {
            s = s.GenerateSlug();
            foreach (var item in currentSlug)
            {
                if (item.Length == s.Length)
                {
                    s += $"-1";
                    break;
                }
                string addPattern = item.Substring(s.Length + 1);
                if (int.TryParse(addPattern, out int num))
                {
                    s += $"-{num + 1}";
                    break;
                }
            }

            return s;
        }

        public static string EncodePassword(this string password)
        {
            return MD5Hash(password + "Safe string");
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}