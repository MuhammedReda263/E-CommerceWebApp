using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }   
        public DbSet<Company> Companies { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } 
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Should with IdentityDbContext
            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 1,  Name = "Scifi", DisplayOrder =1}, 
                new Category {Id = 2 , Name = "History" , DisplayOrder =2},
                new Category {Id = 3, Name = "Action", DisplayOrder =3}
                
                );

            modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = 1,
                Name = "Tech Solutions",
                StreetAddress = "123 Tech St",
                City = "Tech City",
                PostalCode = "12121",
                State = "IL",
                PhoneNumber = "6669990000"
            },
       new Company
       {
           Id = 2,
           Name = "Data Innovations",
           StreetAddress = "456 Data Ave",
           City = "Cloudville",
           PostalCode = "34343",
           State = "CA",
           PhoneNumber = "5551234567"
       },
       new Company
       {
           Id = 3,
           Name = "Web Crafters",
           StreetAddress = "789 Web Blvd",
           City = "Digitalburg",
           PostalCode = "56565",
           State = "NY",
           PhoneNumber = "8884442222"
       },
       new Company
       {
           Id = 4,
           Name = "Code Masters",
           StreetAddress = "321 Algorithm Ln",
           City = "Binarytown",
           PostalCode = "78787",
           State = "TX",
           PhoneNumber = "7773331111"
       },
       new Company
       {
           Id = 5,
           Name = "Pixel Perfect",
           StreetAddress = "654 Design Rd",
           City = "Artville",
           PostalCode = "90909",
           State = "WA",
           PhoneNumber = "2225558888"
       }

       );
            modelBuilder.Entity<Product>().HasData(
                 new Product
                 {
                     Id = 101,
                     Title = "Fortune of Time",
                     Author = "Billy Spark",
                     Description = "Praesent vitae sodales libero...",
                     ISBN = "SWD9999001",
                     ListPrice = 99,
                     Price = 92,
                     Price50 = 85,
                     Price100 = 80,
                     CategoryId = 1,
                     ImageUrl = ""

                 },
    new Product
    {
        Id = 102,
        Title = "Dark Skies",
        Author = "Nancy Hoover",
        Description = "Praesent vitae sodales libero...",
        ISBN = "CAW777777701",
        ListPrice = 40,
        Price = 30,
        Price50 = 29,
        Price100 = 20,
         CategoryId = 3,
        ImageUrl = ""

    },
    new Product
    {
        Id = 103,
        Title = "Vanish in the Sunset",
        Author = "Julian Button",
        Description = "Praesent vitae sodales libero...",
        ISBN = "RITO5555501",
        ListPrice = 55,
        Price = 50,
        Price50 = 48,
        Price100 = 35,
        CategoryId = 2,
        ImageUrl = ""

    },
    new Product
    {
        Id = 104,
        Title = "Cotton Candy",
        Author = "Abby Muscles",
        Description = "Praesent vitae sodales libero...",
        ISBN = "WS3333333301",
        ListPrice = 70,
        Price = 65,
        Price50 = 60,
        Price100 = 53,
        CategoryId = 1,
        ImageUrl = ""

    },
    new Product
    {
        Id = 105,
        Title = "Rock in the Ocean",
        Author = "Ron Parker",
        Description = "Praesent vitae sodales libero...",
        ISBN = "SOTJ1111111101",
        ListPrice = 60,
        Price = 55,
        Price50 = 50,
        Price100 = 55,
        CategoryId = 2,
        ImageUrl = ""

    },
    new Product
    {
        Id = 106,
        Title = "Leaves and Wonders",
        Author = "Laura Phantom",
        Description = "Praesent vitae sodales libero...",
        ISBN = "FOT000000001",
        ListPrice = 80,
        Price = 75,
        Price50 = 70,
        Price100 = 55,
        CategoryId = 3,
        ImageUrl = ""

    },
new Product { Id = 51, Title = "Echoes of Time", Author = "Ava Winters", Description = "An intriguing tale that spans centuries.", ISBN = "FOT000000051", ListPrice = 90, Price = 85, Price50 = 80, Price100 = 70, CategoryId = 1, ImageUrl = "" },
new Product { Id = 52, Title = "Whispers in the Rain", Author = "Liam Frost", Description = "A story of love and mystery.", ISBN = "FOT000000052", ListPrice = 85, Price = 80, Price50 = 75, Price100 = 65, CategoryId = 2, ImageUrl = "" },
new Product { Id = 53, Title = "Mystic Shadows", Author = "Chloe River", Description = "Darkness hides secrets in the woods.", ISBN = "FOT000000053", ListPrice = 70, Price = 65, Price50 = 60, Price100 = 50, CategoryId = 3, ImageUrl = "" },
new Product { Id = 54, Title = "Winds of Fate", Author = "Noah Bright", Description = "A hero rises when all hope fades.", ISBN = "FOT000000054", ListPrice = 75, Price = 70, Price50 = 65, Price100 = 55, CategoryId = 2, ImageUrl = "" },
new Product { Id = 55, Title = "Crystal Horizon", Author = "Isla Dawn", Description = "Adventures in a world of ice and light.", ISBN = "FOT000000055", ListPrice = 95, Price = 90, Price50 = 85, Price100 = 75, CategoryId = 1, ImageUrl = "" },
new Product { Id = 56, Title = "The Silent Sea", Author = "Jack Orion", Description = "When the sea speaks, only few can listen.", ISBN = "FOT000000056", ListPrice = 60, Price = 55, Price50 = 50, Price100 = 45, CategoryId = 3, ImageUrl = "" },
new Product { Id = 57, Title = "Twilight's Edge", Author = "Nora Vale", Description = "At the boundary of light and dark, truths are revealed.", ISBN = "FOT000000057", ListPrice = 78, Price = 73, Price50 = 68, Price100 = 58, CategoryId = 2, ImageUrl = "" },
new Product { Id = 58, Title = "Fire and Ashes", Author = "Leo Hart", Description = "The world must burn before it can rise.", ISBN = "FOT000000058", ListPrice = 88, Price = 83, Price50 = 78, Price100 = 68, CategoryId = 1, ImageUrl = "" },
new Product { Id = 59, Title = "Moonlight Mirage", Author = "Zara Phoenix", Description = "Illusions are sometimes more real than the truth.", ISBN = "FOT000000059", ListPrice = 66, Price = 61, Price50 = 56, Price100 = 46, CategoryId = 3, ImageUrl = "" },
new Product { Id = 60, Title = "The Forgotten Path", Author = "Mason Quinn", Description = "A journey long abandoned is rediscovered.", ISBN = "FOT000000060", ListPrice = 72, Price = 67, Price50 = 62, Price100 = 52, CategoryId = 2, ImageUrl = "" },
new Product { Id = 61, Title = "Beneath the Stars", Author = "Ella Bloom", Description = "Love and fate under a vast sky.", ISBN = "FOT000000061", ListPrice = 100, Price = 95, Price50 = 90, Price100 = 80, CategoryId = 1, ImageUrl = "" },
new Product { Id = 62, Title = "Storm's Call", Author = "Henry Vale", Description = "Nature’s fury awakens ancient powers.", ISBN = "FOT000000062", ListPrice = 83, Price = 78, Price50 = 73, Price100 = 63, CategoryId = 2, ImageUrl = "" },
new Product { Id = 63, Title = "Garden of Secrets", Author = "Maya Thorn", Description = "Every flower hides a secret story.", ISBN = "FOT000000063", ListPrice = 74, Price = 69, Price50 = 64, Price100 = 54, CategoryId = 3, ImageUrl = "" },
new Product { Id = 64, Title = "Ashen Skies", Author = "Owen Reed", Description = "The world above is not what it seems.", ISBN = "FOT000000064", ListPrice = 69, Price = 64, Price50 = 59, Price100 = 49, CategoryId = 2, ImageUrl = "" },
new Product { Id = 65, Title = "The Final Ember", Author = "Sophie Blaze", Description = "A dying flame can spark a revolution.", ISBN = "FOT000000065", ListPrice = 92, Price = 87, Price50 = 82, Price100 = 72, CategoryId = 1, ImageUrl = "" },
new Product { Id = 66, Title = "Mirror of Worlds", Author = "Jasper Hale", Description = "Two realities, one shattered mirror.", ISBN = "FOT000000066", ListPrice = 86, Price = 81, Price50 = 76, Price100 = 66, CategoryId = 3, ImageUrl = "" },
new Product { Id = 67, Title = "Veil of Ice", Author = "Aria Frost", Description = "Cold lands hide warm hearts.", ISBN = "FOT000000067", ListPrice = 77, Price = 72, Price50 = 67, Price100 = 57, CategoryId = 1, ImageUrl = "" },
new Product { Id = 68, Title = "Threads of Time", Author = "Eli Stone", Description = "Time weaves destinies in strange ways.", ISBN = "FOT000000068", ListPrice = 84, Price = 79, Price50 = 74, Price100 = 64, CategoryId = 2, ImageUrl = "" },
new Product { Id = 69, Title = "Song of the Sands", Author = "Luna Ray", Description = "A desert of secrets and songs.", ISBN = "FOT000000069", ListPrice = 73, Price = 68, Price50 = 63, Price100 = 53, CategoryId = 3, ImageUrl = "" },
new Product { Id = 70, Title = "Legacy of Dawn", Author = "Kai Ember", Description = "Hope rises with the sun.", ISBN = "FOT000000070", ListPrice = 82, Price = 77, Price50 = 72, Price100 = 62, CategoryId = 1, ImageUrl = "" }

                );
        }
    }
}
