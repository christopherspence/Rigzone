using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rigzone.Models
{
    public class Location : LookupModel
    {
        public string BlockOrWell { get; set; }
        public Country Country { get; set; }
        public Region Region { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
