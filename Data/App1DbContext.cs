using App1.Domain;
using App1.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App1.Data
{
    public class App1DbContext : IdentityDbContext
    {
        public App1DbContext(DbContextOptions<App1DbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var readerRoleId = "88e141d6-e1fc-468e-ae1f-d62faa30e879";
            var writerRoleId = "b4b4b4b4-b4b4-b4b4-b4b4-b4b4b4b4b4b4";

            var roles = new List<IdentityRole>
            {
                new IdentityRole{Id=readerRoleId,ConcurrencyStamp=readerRoleId,Name="Reader",NormalizedName="READER"},
                new IdentityRole{Id=writerRoleId,ConcurrencyStamp=writerRoleId,Name="Writer",NormalizedName="writer".ToUpper()}
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            //Seed data for Difficulties
            //Easy, Medium and Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty{Id=Guid.Parse("00de2fc6-b361-43ac-b422-f80484c66c94"),Name="Easy"},
                new Difficulty{Id=Guid.Parse("b968fb54-a85d-45cf-a498-3e0fd4ed310a"),Name="Medium"},
                new Difficulty{Id=Guid.Parse("41558971-053d-48f4-9f89-be4f25def2da"),Name="Hard"}
            };

            //Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //Seed data for Regions
            var regions = new List<Region>()
            {
              new Region{
                Id=Guid.Parse("50422e00-4251-43e0-b478-e9b7a34b8185"),
                Code="NW",
                Name="North West",
                RegionImageUrl="https://www.visitbritain.com/sites/default/files/styles/wysiwyg_image/public/consumer/paragraphs_bundles/image/visitbritain-north-west-england-lake-district-cumbria-ambleside-bridge-house-visitbritain-robert-harding.jpg?itok=3J9J9Q8w"
              },
              new Region{
                Id=Guid.Parse("f3b3b3b3-1b3b-4b3b-8b3b-3b3b3b3b3b3b"),
                Code="NE",
                Name="North East",
                RegionImageUrl="https://www.visitbritain.com/sites/default/files/styles/wysiwyg_image/public/consumer/paragraphs_bundles/image/visitbritain-north-east-england-northumberland-bamburgh-castle-visitbritain-robert-harding.jpg?itok=3J9J9Q8w"

              },
                new Region{
                    Id=Guid.Parse("d694bbc6-e540-41db-a495-53662435522b "),
                    Code="SW",
                    Name="South West",
                    RegionImageUrl="https://www.visitbritain.com/sites/default/files/styles/wysiwyg_image/public/consumer/paragraphs_bundles/image/visitbritain-south-west-england-cornwall-st-ives-tate-modern-visitbritain-andrew-boxall.jpg?itok=3J9J9Q8w"

                },
                new Region{
                    Id=Guid.Parse("b04d0f8b-aba6-40f8-a4b0-e3797d67ab28"),
                    Code="SE",
                    Name="South East",
                    RegionImageUrl="https://www.visitbritain.com/sites/default/files/styles/wysiwyg_image/public/consumer/paragraphs_bundles/image/visitbritain-south-east-england-brighton-pier-visitbritain-andrew-boxall.jpg?itok=3J9J9Q8w"

                },
            };
            //Seed regions to the database
            modelBuilder.Entity<Region>().HasData(regions);

        }

    }
}