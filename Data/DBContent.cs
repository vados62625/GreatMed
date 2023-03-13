using MotoHelp.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MotoHelp.Data
{
    public class DBContent : IdentityDbContext<IdentityUser>
    {

        public DBContent(DbContextOptions<DBContent> options) : base (options)
        {

        }

        public DbSet<MHService> MHService { get; set; }
        public DbSet<MHDetail> MHDetail { get; set; }
        public DbSet<MHCategory> MHCategory { get; set; }
        public DbSet<RequestedCall> RequestedCall { get; set; }
        public DbSet<ImageUri> ImageUri { get; set; }
        public DbSet<TextField> TextFields { get; set; }
        //public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                Name = "PageIndex",
                Title = "Главная"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                Name = "PageAbout",
                Title = "О нас"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("64de805e-a62a-11ed-afa1-0242ac120002"),
                Name = "PagePrivacy",
                Title = "Политика конфиденциальности"
            });
            //modelBuilder.Entity<TextField>().HasData(new TextField
            //{
            //    Id = new Guid("6f774f00-a62a-11ed-afa1-0242ac120002"),
            //    Name = "PageAbout",
            //    Title = "О нас"
            //});
            //modelBuilder.Entity<TextField>().HasData(new TextField
            //{
            //    Id = new Guid("7c9cc034-a62a-11ed-afa1-0242ac120002"),
            //    Name = "PageAbout",
            //    Title = "О нас"
            //});
            //builder.Entity<MHDetailCategory>()
            //    .HasIndex(u => u.Url)
            //    .IsUnique();

            //builder.Entity<MHDetail>()
            //    .HasMany(c => c.Price)
            //    .WithOptional(o => o.MHDetail);
            //builder.Entity<ImageUri>()
            //    .HasOne(c => c.MHDetailTitle)
            //    .WithOne(c => c.TitlePictire)
            //    .HasForeignKey<ImageUri>(c => c.Id).IsRequired();
            //builder.Entity<ImageUri>()
            //    .HasOne(c => c.MHDetailAdditional)
            //    .WithMany(c => c.AdditionalPictures);

            //builder.Entity<MHDetail>()
            //    .HasOne(c => c.TitlePictire)
            //    .WithOne(c => c.MHDetailTitle)
            //    .HasForeignKey(c => c.MHDetailTitleId);
        }
    }
}
