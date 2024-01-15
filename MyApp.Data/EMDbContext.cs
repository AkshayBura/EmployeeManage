using Microsoft.EntityFrameworkCore;
using MyApp.Model;
using System.Collections.Generic;

namespace MyApp.Data
{
    public class EMDbContext : DbContext
    {
        public EMDbContext(DbContextOptions<EMDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<PersonalDetails> PersonalDetails { get; set; }
        public DbSet<EmploymentDetails> EmploymentDetails { get; set;}
    }
}
