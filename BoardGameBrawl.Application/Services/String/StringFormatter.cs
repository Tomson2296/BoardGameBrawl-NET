using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Services.String
{
    public class StringFormatter : IStringFormatter
    {
        public string FormatString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string withSpace = Regex.Replace(
                input,
                @"(\p{Ll})(games)$", 
                "$1 $2"             
            );

            // Capitalize each word (e.g., "strategy games" → "Strategy Games")
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(withSpace);
        }
    }
}
