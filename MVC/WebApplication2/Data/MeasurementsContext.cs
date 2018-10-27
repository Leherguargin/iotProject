using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class MeasurementsContext : DbContext
    {
        public MeasurementsContext (DbContextOptions<MeasurementsContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication2.Models.Measurements> Measurements { get; set; }
    }
}
