using Microsoft.EntityFrameworkCore;

namespace UserApp.EFCore.Models
{
    public class UserAppDbContext : DbContext
    {

        public UserAppDbContext() { }

        public UserAppDbContext(DbContextOptions<UserAppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=LI1106; database=UserApp; User ID = sa; password=tools5&Broad?=; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Email = "uncle.bob@gmail.com",
                FirstName = "Uncle",
                LastName = "Bob",
                DateOfBirth = new DateTime(1970, 05, 20)
            }, new User()
            {
                Id = 2,
                Email = "uncle.sam@gmail.com",
                FirstName = "Uncle",
                LastName = "Sam",
                DateOfBirth = new DateTime(1970, 05, 20)
            });
        }
    }
}
