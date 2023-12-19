using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace DataLayer.EFContext
{
    public class DbSqLiteContext: ADbContext
    {
        public string DbPath; 

        public DbSqLiteContext()
        {
            // Path for local DB dir
            var path = @"D:\MyGitProjects\CarOwner\";
            DbPath = System.IO.Path.Join(path, "CarOwner.db");
        }

        // The following configures EF to create a Sqlite database file
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
