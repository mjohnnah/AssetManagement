using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public int AssetID { get; set; }
        public int AssigneeID { get; set; }
        public ProgramLocation? ProgramLocation { get; set; }

        public Asset Asset { get; set; }
        public Assignee Assignee { get; set; }
    }

    public enum ProgramLocation
    {
        PTC, MTC, STC, KTC, PH, SLP, TNE, ADMIN, FIN, HR
    }
}
