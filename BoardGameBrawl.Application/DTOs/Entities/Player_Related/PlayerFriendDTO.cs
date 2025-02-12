using AutoMapper;
using BoardGameBrawl.Domain.Entities.Player_Related;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.DTOs.Entities.Player_Related
{
    [AutoMap(typeof(PlayerFriend))]
    public class PlayerFriendDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid RequesterId { get; set; }

        public string? RequesterName { get; set; }

        public Guid AddresseeId { get; set; }

        public string? AddresseeName { get; set; }

        public DateTime FriendshipDate { get; set; }

        public FriendshipStatus Status { get; set; }
    }
}
