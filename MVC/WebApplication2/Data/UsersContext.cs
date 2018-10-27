using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.model;

namespace WebApplication2.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext (DbContextOptions<UsersContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication2.model.Users> Users { get; set; }
    }
}
