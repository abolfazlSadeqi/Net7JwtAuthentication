
using DAL.Entities;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Emit;

namespace DAL.Contexts;


public partial class TestCurdContext :
    IdentityDbContext<ApplicationUser, ApplicationRole, long, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
{
    public TestCurdContext(DbContextOptions<TestCurdContext> options)
        : base(options)
    {
    }

    public DbSet<Person> Persons => Set<Person>();
    

    protected override void OnModelCreating(ModelBuilder builder)
    {



        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>()
            .ToTable("Users");

        builder.Entity<ApplicationRole>().ToTable("Roles");
        builder.Entity<ApplicationUserRole>().ToTable("UserRoles");
        builder.Entity<ApplicationUserLogin>().ToTable("UserLogins");
        builder.Entity<ApplicationUserClaim>().ToTable("UserClaims");
        builder.Entity<ApplicationRoleClaim>().ToTable("RoleClaims");
        builder.Entity<ApplicationUserToken>().ToTable("UserTokens");


     
       
    }

 
}


