using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c969v2.Models
{
    internal class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public DateTime DateTime { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdate { get; set; }
        public string LastUpdatedBy { get; set; }

    }
}
