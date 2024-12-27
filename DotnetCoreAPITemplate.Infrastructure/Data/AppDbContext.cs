using Microsoft.EntityFrameworkCore;
using DotnetCoreAPITemplate.Domain.Entities;
using System.Collections.Generic;

namespace DotnetCoreAPITemplate.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
