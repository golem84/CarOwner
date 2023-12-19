using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.EFClasses;

namespace DataLayer.EFContext
{
    public class ADbContext: DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }

    }

    public interface IDbContext
    {

    }
}
