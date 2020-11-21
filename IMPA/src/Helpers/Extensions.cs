using System;
using System.Security.Claims;

namespace IMPA
{
    public static class Extensions
    {
        public static User GetUser(this ClaimsPrincipal principal, DatabaseController databaseController)
        {
            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);

            if (claim is null)
            {
                throw new UnauthorizedAccessException();
            }

            return databaseController.Users.Get(new Guid(claim.Value));
        }
    }
}
