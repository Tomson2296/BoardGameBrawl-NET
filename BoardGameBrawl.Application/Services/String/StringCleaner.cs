using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace BoardGameBrawl.Application.Services.String
{
    public class StringCleaner : IStringCleaner
    {
        public string CleanDescription(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string decoded = WebUtility.HtmlDecode(input);
            string cleaned = decoded.Replace("&#10;", "\n");

            cleaned = cleaned.Trim();
            cleaned = Regex.Replace(cleaned, @"\n{2,}", "\n");

            return cleaned;
        }
    }
}
