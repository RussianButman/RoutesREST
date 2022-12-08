using Microsoft.AspNetCore.Identity;
using RoutesREST.Models.Entities;
using System.Text.Json.Serialization;

namespace RoutesREST.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateOnly BirthDate { get; set; }
        public virtual BypassRouteInstance BypassRouteInstance { get; set; }
        public Guid? RouteInstanceId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public override string NormalizedUserName { get; set; }
        [ProtectedPersonalData]
        public override string Email { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public override string NormalizedEmail { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        [PersonalData]
        public override bool EmailConfirmed { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public override string PasswordHash { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public override string SecurityStamp { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public override string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
        [ProtectedPersonalData]
        public override string? PhoneNumber { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        [PersonalData]
        public override bool PhoneNumberConfirmed { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        [PersonalData]
        public override bool TwoFactorEnabled { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public override DateTimeOffset? LockoutEnd { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public override bool LockoutEnabled { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public override int AccessFailedCount { get; set; }
    }
}
