using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace kamafi.core.middleware.tests
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}
