using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using wingsApi.Models;

namespace wingsApi.Data
{
    public class wingsDbContext: DbContext
    {
        public wingsDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<user_table> user_table { get; set; }
    }
}
