using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.model
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
    }
}
