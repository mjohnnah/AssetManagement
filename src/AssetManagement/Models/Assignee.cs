using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class Assignee
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string LastMidName { get; set; }

        public ICollection<Assignment> Asssignments { get; set; }
    }
}
