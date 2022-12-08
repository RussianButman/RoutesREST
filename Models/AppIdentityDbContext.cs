using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoutesREST.Models.Entities;
using System.Reflection.Emit;

namespace RoutesREST.Models
{
    public partial class ApplicationDbContext : IdentityDbContext<AppUser>
    {

    }
}
