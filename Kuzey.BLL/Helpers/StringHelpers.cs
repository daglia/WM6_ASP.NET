using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Kuzey.BLL.Helpers
{
    public static class StringHelpers
    {
        public static string UrlFormatConverter(string name)
        {
            string sonuc = name.ToLower();
            sonuc = sonuc.Replace("'", "");
            sonuc = sonuc.Replace(" ", "-");
            sonuc = sonuc.Replace("<", "");
            sonuc = sonuc.Replace(">", "");
            sonuc = sonuc.Replace("&", "");
            sonuc = sonuc.Replace("[", "");
            sonuc = sonuc.Replace("!", "");
            sonuc = sonuc.Replace("]", "");
            sonuc = sonuc.Replace("ı", "i");
            sonuc = sonuc.Replace("ö", "o");
            sonuc = sonuc.Replace("ü", "u");
            sonuc = sonuc.Replace("ş", "s");
            sonuc = sonuc.Replace("ç", "c");
            sonuc = sonuc.Replace("ğ", "g");
            sonuc = sonuc.Replace("İ", "I");
            sonuc = sonuc.Replace("Ö", "O");
            sonuc = sonuc.Replace("Ü", "U");
            sonuc = sonuc.Replace("Ş", "S");
            sonuc = sonuc.Replace("Ç", "C");
            sonuc = sonuc.Replace("Ğ", "G");
            sonuc = sonuc.Replace("|", "");
            sonuc = sonuc.Replace(".", "-");
            sonuc = sonuc.Replace("?", "-");
            sonuc = sonuc.Replace(";", "-");
            sonuc = sonuc.Replace("#", "-sharp");
            sonuc = sonuc.Replace("/", "-");
            sonuc = sonuc.Replace(@"\", "-");
            sonuc = sonuc.Replace("ß", "ss");
            sonuc = sonuc.Replace("ë", "e");
            sonuc = sonuc.Replace("ä", "a");
            sonuc = sonuc.Replace("à", "a");
            sonuc = sonuc.Replace("á", "a");
            sonuc = sonuc.Replace("æ", "ae");
            sonuc = sonuc.Replace("í", "i");
            sonuc = sonuc.Replace("ì", "i");
            sonuc = sonuc.Replace("ñ", "n");
            sonuc = sonuc.Replace("é", "e");
            sonuc = sonuc.Replace("è", "e");
            sonuc = sonuc.Replace("ô", "o");
            sonuc = sonuc.Replace("â", "a");

            // falan filan
            //
            //       *
            //      / \           string
            //     /___\          helper
            //   ~(´`v´`)~        civciv
            //     ´   ` 

            return sonuc;
        }

        public static string Capitalize(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            var items = text.Split(' ');
            var result = string.Empty;
            foreach (var item in items)
            {
                if (item.Length > 1)
                    result += $"{item.Substring(0, 1).ToUpper()}{item.Substring(1).ToLower()}";
                else
                    result += $"{item} ";
            }

            return result.Trim();
        }

        public static string GetCode() =>
            Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "").ToLower(new CultureInfo("en-US", false));
    }
}