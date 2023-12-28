using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EFClasses
{
    public enum SType : byte
    {
        TO = 0, TR = 1, KR = 2, TUN = 3
    }

    public class Service
    {
        public int ServiceId { get; set; }

        public DateOnly Date { get; set; }
        public int DistanceValue { get; set; }
        public SType SType { get; set; }
        public string Description { get; set; }
        public decimal PartsPrice { get; set; }
        public decimal ServicePrice { get; set; }

        //public int AddressId { get; set; }
        public Address Address { get; set; }        
    }
}
