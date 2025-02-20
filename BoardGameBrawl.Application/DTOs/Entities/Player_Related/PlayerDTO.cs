﻿using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities.Player_Related;

namespace BoardGameBrawl.Application.DTOs.Entities.Player_Related
{
    [AutoMap(typeof(Player))]
    public class PlayerDTO
    {
        public Guid Id { get; set; }

        public Guid ApplicationUserId { get; set; }

        public required string PlayerName { get; set; }

        public required string Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? BGGUsername { get; set; }

        public string? UserDescription { get; set; }

        public byte[]? UserAvatar { get; set; }
    }
}
