using System.Security.Claims;

namespace KaryeramAPI.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (claim == null) throw new UnauthorizedAccessException();
            return int.Parse(claim);
        }
    }
}
