﻿using Microsoft.AspNetCore.Identity;

namespace BoardGameBrawl.Application.Contracts.Entities.Identity_Related
{
    public interface IApplicationRoleStore<TRole> : 
        IRoleStore<TRole>, 
        IRoleClaimStore<TRole>,
        IQueryableRoleStore<TRole> where TRole : class
    {
    }
}
