using DataLayer.EFClasses;
using DataLayer.EFContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ServiceCode
{
    public class Seeder
    {
        /// <summary>
        /// Seeding data
        /// </summary>
        private User user = new User() { UserName = "TestUser1" };
        private Car car = new Car() { Brand = "Lexus", Model = "RX MX1", RegNumber = "T147EM159RUS" };
        private Address address = new Address() { Description = "Юрша 100 English only?" };
        private ICollection<Distance> distances = new List<Distance>()
        {
            new Distance() { Date = new DateOnly(2022,01,06), Value= 30000 },
            new Distance() { Date = new DateOnly(2022,03,06), Value= 35000 },
            new Distance() { Date = new DateOnly(2022,04,06), Value= 36500 },
        };

    private Service service = new Service()
    {
        Date = new DateOnly(2022, 02, 15),
        DistanceValue = 32400,
        SType = 0,
        Description = "ServiceDesctiption from Seeder",
        PartsPrice = 2250,
        ServicePrice = 3340,
        Address = new Address { Description = "Descr address from Seeder" }
        };
        
        // dbContext
        private readonly ADbContext db;
        public ADbContext DB { get => db; }
        // constructor
        public Seeder(ADbContext d) => this.db = d;

        // methods
        public User FindUser()
        {
            var user = db.Users.Where(u => u.UserName == "TestUser1").FirstOrDefault();
            return user;
        }

        public Car FindCar()
        {
            var car = db.Cars.Where(c => c.Model == "RX MX1").FirstOrDefault();
            return car;
        }

        public void SeedUser()
        {
            var user = FindUser();
            if (user==null)
            db.Add(this.user);
            db.SaveChanges();
        }

        public void SeedCar()
        {
            var car = FindCar();
            if (car == null)
            {
                var user = FindUser();
                if (user == null) SeedUser();
                user = FindUser();
                this.car.User = user;
                db.Add(this.car);
                db.SaveChanges();
            }            
        }

        public void SeedDistances()
        {
            SeedCar();
            var car = FindCar();
            car.Distances = this.distances;
            db.SaveChanges();
        }

        public void SeedService()
        {
            SeedCar();
            var car = FindCar();
            List<Service> serv = new();
            serv.Add(this.service);
            car.Services = serv;
            db.SaveChanges();
        }

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
            var cars = db.Cars.AsNoTracking().Include(car => car.User).Include(d => d.Distances).Include(s => s.Services).ToList();
            foreach (var c in cars)
            {
                Console.WriteLine($"{c.Brand}\t{c.Model}\t{c.RegNumber}" +
                    $"\t\tвладелец: {c.User.UserName} (id={c.User.UserId})");
                var dist = c.Distances;
                Console.WriteLine("Distances:");
                foreach (var d in dist)
                    Console.WriteLine($"\t\t{d.Date}\t{d.Value}");
                var serv = c.Services;
                Console.WriteLine("Serivces:");
                foreach (var s in serv)
                    Console.WriteLine($"\t\t{s.SType}\t{s.DistanceValue}\t{s.Date}\t{s.Description}");
            }

        }

        public void DeleteData()
        {
            var user = FindUser();
            db.Remove(user);
            db.SaveChanges();
        }
    }
}
