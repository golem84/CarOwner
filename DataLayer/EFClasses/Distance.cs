using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EFClasses
{
    public class Distance
    {
        public int DistanceId { get; set; }

        public DateOnly Date { get; set; }
        public int Value { get; set; }
    }
}
