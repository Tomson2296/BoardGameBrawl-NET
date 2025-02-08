using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Services.String
{
    public interface IStringCleaner
    {
        public string CleanDescription(string input);
    }
}
