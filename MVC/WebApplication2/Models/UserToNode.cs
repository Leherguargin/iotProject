using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.model
{
    public class UserToNode
    {
        [Key]
        public int UserSensorID { get; set; }
        public int UserID { get; set; }
        public int NodeID { get; set; }
        public int Authorizations { get; set; }
    }
}
