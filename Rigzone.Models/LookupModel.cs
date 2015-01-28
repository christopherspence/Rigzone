using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rigzone.Models
{
    /// <summary>
    /// Lookup models are suitable for dropdowns-type objects. 
    /// </summary>
    public abstract class LookupModel : BaseModel
    {
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }
}
