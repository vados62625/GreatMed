using GreatMed.Models;
using Microsoft.EntityFrameworkCore;

namespace GreatMed.Data
{
    public class DBContent : DbContext
    {

        public DBContent(DbContextOptions<DBContent> options) : base (options)
        {

        }

        public DbSet<GMService> GMService { get; set; }

    }
}
