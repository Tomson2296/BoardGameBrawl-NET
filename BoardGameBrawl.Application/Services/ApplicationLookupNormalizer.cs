using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace BoardGameBrawl.Application.Services
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
