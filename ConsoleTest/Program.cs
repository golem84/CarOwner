//using DataLayer;
using DataLayer.EFContext;
using DataLayer.ServiceCode;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Console test for DataLayer in EF Core DB");

var db = new DbSqLiteContext();

db.Database.EnsureCreated();
Console.WriteLine($"Path = {db.DbPath}");

var seeder = new Seeder(db);

seeder.SeedUser();
seeder.SeedCar();
//seeder.SeedDistances();
//seeder.SeedService();
seeder.printAllInfo();
Console.WriteLine("Ждем нажатия Enter ..");
Console.ReadLine();
//seeder.DeleteData();

