using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public interface IBasarsoftDbContext
    {

        DbSet<Door> Doors { get; set; }
        DbSet<OperationClaim> OperationClaims { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
