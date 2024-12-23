using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Infrastructure.EmailSender
{
    public interface IMailKitEmailSender
    {
        public Task SendEmailAsync(string to, string subject, string message);
    }
}
