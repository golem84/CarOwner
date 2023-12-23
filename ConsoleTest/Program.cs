using DataLayer;
using DataLayer.EFContext;
using DataLayer.ServiceCode;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Console test for DataLayer in EF Core DB");

var db = new DbSqLiteContext();

db.Database.EnsureCreated();
Console.WriteLine($"Path = {db.DbPath}");

var seeder = new Seeder(db);

seeder.Seed();
/*seeder.PrintUsers();
seeder.PrintCars();*/
seeder.printAllInfo();
Console.WriteLine("Ждем команду перед удалением данных");
Console.ReadLine();
seeder.DeleteData();

