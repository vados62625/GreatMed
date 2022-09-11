using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GreatMed.Data
{
    public class DBContent : DbContext
    {

        public DBContent(DbContextOptions<DBContent> options) : base (options)
        {

        }

        public DbSet<GMService> GMService { get; set; }

        //protected override void OnModelCreating (ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating (modelBuilder);
        //    modelBuilder.Entity<GMService>().HasData(new GMService
        //    {
        //        Id = "13a77c93-aa5e-4fdc-820e-74f628cf7b37",
        //        Name = "Запись к врачу",
        //        Description = $"В нашей компании работают высококвалифицированные специалисты, можете записаться на прием по телефону {Service.GMService.CompanyPhone}"
        //    });
        //}

    }
}
