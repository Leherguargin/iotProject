using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.model;

namespace WebApplication2.Models
{
    public class UserToNodesContext : DbContext
    {
        public UserToNodesContext (DbContextOptions<UserToNodesContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication2.model.UserToNode> UserToNode { get; set; }
    }
}
