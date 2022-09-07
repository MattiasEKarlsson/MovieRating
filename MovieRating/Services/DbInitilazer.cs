using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieRating.Data;
using SharedLibrary;

namespace MovieRating.Services
{
    public class DbInitilazer : IDbInitilazer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        

        public DbInitilazer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            
        }

        public void Initilize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {
            }

            if (_db.Roles.Any(x => x.Name == SD.Role_Admin)) return;
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_User)).GetAwaiter().GetResult();


            _userManager.CreateAsync(new IdentityUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true
            }, "Admin123!").GetAwaiter().GetResult();

            IdentityUser user = _db.Users.FirstOrDefault(u => u.Email == "admin@admin.com");
            _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

            var movie = new Movie { Id = 10, Title = "Hulk", Description = "Bruce Banner, a genetics researcher with a tragic past, suffers an accident that causes him to transform into a raging green monster when he gets angry.", Director = "Ang Lee", Url = "Hulk2003", DateCreate = DateTime.Now };
            _db.Movies.AddAsync(movie);
            _db.SaveChangesAsync();
        }
        
    }
}
