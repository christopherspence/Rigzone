using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rigzone.Models
{
    public abstract class BaseModel
    {
        #region Fields

        private string _name;

        #endregion

        #region Properties

        public Guid ID { get; set; }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Name cannot be null or empty.");

                _name = value;
            }
        }

        #endregion
    }
}
