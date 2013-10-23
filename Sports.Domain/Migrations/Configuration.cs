namespace Sports.Domain.Migrations
{
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;
  using System.Web.Security;
  using WebMatrix.WebData;

  internal sealed class Configuration : DbMigrationsConfiguration<Sports.Domain.Concrete.EFDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = true;
    }

    protected override void Seed(Sports.Domain.Concrete.EFDbContext context)
    {
      WebSecurity.InitializeDatabaseConnection("EFDbContext",
                                               "UserProfile",
                                               "UserId",
                                               "Email",
                                                autoCreateTables: true);

      if (!Roles.RoleExists("Administrator"))
        Roles.CreateRole("Administrator");

      if (!WebSecurity.UserExists("admin@test.com"))
        WebSecurity.CreateUserAndAccount("admin@test.com", "letmein", new { DisplayName="Admin" });

      if (!Roles.GetRolesForUser("admin@test.com").Contains("Administrator"))
        Roles.AddUserToRole("admin@test.com", "Administrator");
    }
  }
}
