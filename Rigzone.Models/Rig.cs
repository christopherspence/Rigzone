using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rigzone.Models
{
    public class Rig : BaseModel
    {
        #region Fields
        
        private int _waterDepth;
        private int _drillingDepth;

        #endregion

        #region Properties

        public int WaterDepth 
        { 
            get
            {
                return _waterDepth;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Water Depth cannot be less than zero.");
                
                _waterDepth = value;
            }
        }
        public int DrillingDepth
        {
            get
            {
                return _drillingDepth;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Drilling Depth cannot be less than zero.");
         
              }
        }

        public Organization Manager { get; set; }

        public Location Location { get; set; }

        // TODO: Future impl.
        // public List<Location> PreviousLocations { get; set; }

        #endregion
    }
}
