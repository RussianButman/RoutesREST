using Microsoft.AspNetCore.Identity;

namespace RoutesREST.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
