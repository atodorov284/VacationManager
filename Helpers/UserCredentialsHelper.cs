using System.Linq;
using System.Security.Claims;
using VacationManager.Repositories;

namespace VacationManager.Helpers
{
    public class UserCredentialsHelper
    {
        public static int FindUserId(VacationManagerDbContext _context, ClaimsPrincipal User)
        {

            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            int userId = _context.Users.FirstOrDefault(u => u.Username == userEmail).UserId;
            return userId;
        }
        public static string FindUserRole(ClaimsPrincipal User)
        {
            VacationManagerDbContext _context = new VacationManagerDbContext();
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            string userRole = _context.Users.FirstOrDefault(u => u.Username == userEmail).Role.ToString();
            return userRole;
        }
        public static string FindUserRole(VacationManagerDbContext _context, ClaimsPrincipal User)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            string userRole = _context.Users.FirstOrDefault(u => u.Username == userEmail).Role.ToString();
            return userRole;
        }
    }
}
