using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class NodesContext : DbContext
    {
        public NodesContext (DbContextOptions<NodesContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication2.Models.Nodes> Nodes { get; set; }
    }
}
