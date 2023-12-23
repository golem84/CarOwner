using DataLayer.EFClasses;
using DataLayer.EFContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ServiceCode
{
    public class Seeder
    {
        private readonly ADbContext db;

        public ADbContext DB { get => db; }

        public Seeder(ADbContext d) => this.db = d;

        public void Seed()
        {
            db.Database.EnsureCreated();

            var user1 = new User() { UserName = "TestUser1" };
            var user2 = new User() { UserName = "Andrew" };

            var car1 = new Car() { Brand = "Lexus", Model = "RX MX", RegNumber = "T147EM159RUS", User = user1 };
            var car2 = new Car() { Brand = "Lada", Model = "Granta", RegNumber = "C223TA159RUS", User = user1 };

            

            db.Add(user1);
            db.Add(user2);

            db.Add(car1);
            db.Add(car2);

            db.SaveChanges();
        }

        /*public void Dispose()
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }*/

        public void PrintUsers()
        {
            var users = db.Users.AsNoTracking().ToList();
            Console.WriteLine("List of Users:");
            foreach (var u in users)
            {
                Console.WriteLine(u.UserName);
            }
        }

        public void PrintCars()
        {
            var cars = db.Cars.AsNoTracking().ToList();
            Console.WriteLine("List of Cars:");
            foreach (var c in cars)
            {
                Console.WriteLine($"{c.Brand}\t{c.Model}\t{c.RegNumber}");
            }
        }

        public void printAllInfo()
        {
            Console.WriteLine("List of Cars:");
            var cars = db.Cars.AsNoTracking().Include(car => car.User).ToList();
            foreach (var c in cars)
            {
                Console.WriteLine($"{c.Brand}\t{c.Model}\t{c.RegNumber}" +
                    $"\t\tвладелец:{c.User.UserName} {c.User.UserId}");
            }
        }

        public void DeleteData()
        {
            var users = db.Users.ToList();
            foreach (var u in users)
                db.Remove(u);
            db.SaveChanges();
        }
    }
}
