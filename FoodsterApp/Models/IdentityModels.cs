using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FoodsterApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Hometown { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<FoodModel> FoodModels { get; set; }
        public DbSet<FoodRatingModel> FoodRatings { get; set; }
        public DbSet<MealModel> MealModels { get; set; }
        public DbSet<PhotoModel> PhotoModels { get; set; }
        public DbSet<PriceRangeModel> PriceRangeModels { get; set; }
        public DbSet<RestaurantModel> RestaurantModels { get; set; }
        public DbSet<TagModel> TagModels { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }
    

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}