using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities
{
    public class AppUser 
    {
        public Guid Id { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? BGGUsername { get; set; }

        public string? UserDescription { get; set; }

        public byte[]? UserAvatar { get; set; }

        public DateTime? UserLastLogin { get; set; }


        public ICollection<GroupParticipants>? GroupParticipants { get; set; }

        public ICollection<UserRatings>? UserRatings { get; set; }
    }
}
