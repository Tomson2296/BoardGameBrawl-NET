using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Identity.Services
{
    public class ApplicationLookupNormalizer : ILookupNormalizer
    {
        [return: NotNullIfNotNull("email")]
        public string? NormalizeEmail(string? email)
        {
            return email?.Normalize().ToLowerInvariant();
        }

        [return: NotNullIfNotNull("name")]
        public string? NormalizeName(string? name)
        {
            return name?.Normalize().ToLowerInvariant();
        }
    }
}
