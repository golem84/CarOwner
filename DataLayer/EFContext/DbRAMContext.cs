using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.EFClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace DataLayer.EFContext
{
    public class DbRAMContext: ADbContext, IDbContext
    {


    }
}
