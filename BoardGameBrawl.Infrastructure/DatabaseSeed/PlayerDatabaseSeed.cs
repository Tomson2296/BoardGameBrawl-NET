#nullable disable
using AutoMapper;
using AutoMapper.Execution;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Player_Related.PlayerCollections.Commands.AddPlayerCollection;
using BoardGameBrawl.Application.Features.Player_Related.Players.Commands.AddPlayer;
using BoardGameBrawl.Application.Features.Player_Related.Players.Queries.CheckIfPlayerByAppIdExists;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Persistence;
using BoardGameBrawl.Persistence.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Infrastructure.DatabaseSeed
{
    public class PlayerDatabaseSeed
    {
        private readonly MainAppDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public PlayerDatabaseSeed(MainAppDBContext context, UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _context = context;
            _userManager = userManager;
            _mediator = mediator;
        }

        public async Task SeedDatabaseAsync()
        {
            if (await _context.Players.CountAsync() != 0)
            {
                return;
            }
            else
            {
                // getting list of all applicationUser in application

                IList<ApplicationUser> appUsers = await _userManager.GetAllApplicationUsers();

                foreach (var user in appUsers)
                {
                    PlayerDTO entry = new()
                    {
                        Id = Guid.NewGuid(),
                        PlayerName = user.UserName,
                        Email = user.Email,
                        ApplicationUserId = user.Id 
                    };

                    // check if user exists in player table in MainAppDBContext
                    var check = new CheckIfPlayerByAppIdExistsQuery { PlayerDTO = entry };
                    var result = await _mediator.Send(check);

                    // entity != null
                    if (result == false)
                    {
                        var addPlayer = new AddPlayerCommand { PlayerDTO = entry };
                        await _mediator.Send(addPlayer);
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}