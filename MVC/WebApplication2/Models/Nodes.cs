using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Nodes
    {
        [Key]
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public string Localization { get; set; }
        public string NodePassword { get; set; }
    }
}
