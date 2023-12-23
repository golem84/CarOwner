using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EFClasses
{
    public class Car
    {
        public int CarId { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string RegNumber { get; set; }
        //public DateOnly? PurchaseDate { get; set; }
        //public int PurchaseDistance { get; set; }
        public ICollection<Distance> Distances { get; set; }
        public ICollection<Service> Services { get; set; }

        /// Навигационные свойства
        public User User { get; set; }
    }
}
