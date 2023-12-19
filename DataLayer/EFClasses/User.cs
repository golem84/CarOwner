using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EFClasses
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
        //public string Login { get; set; }
        //public string Password { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
