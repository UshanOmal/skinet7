
using System.Security.Claims;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ClaimsPricipalExtensions
    {
       public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal user)
       {
            return user.FindFirstValue(ClaimTypes.Email);
       }
    }
}

