using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class BasarsoftDbContext : DbContext, IBasarsoftDbContext
    {
        protected readonly IConfiguration Configuration;
        public BasarsoftDbContext(IConfiguration configuration)
        { Configuration = configuration; }
        public BasarsoftDbContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        { options.UseNpgsql("Host=localhost;Database=OpenLayersProject" +
                                           ";Username=postgres;Password=12345"); }
        public DbSet<Door> Doors { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}


