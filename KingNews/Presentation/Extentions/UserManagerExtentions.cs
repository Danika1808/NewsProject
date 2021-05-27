using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Presentation.Extentions
{
    public static class UserManagerExtentions
    {
        public static async Task<bool> IsNameAlreadyExistAsync(this UserManager<User> manager, string email) =>
            await manager.FindByEmailAsync(email) != null;
        public static User GetUserIncludeProfile(this UserManager<User> manager,
    ClaimsPrincipal principal) =>
         manager.Users
        .Where(u => u.Id.Equals(manager.GetUserId(principal)))
        .Include(u => u.Profile)
        .Single();
    }
}
