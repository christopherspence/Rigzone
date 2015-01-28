using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rigzone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rigzone.Tests.ModelTests
{
    [TestClass]
    public class RigTests
    {
        [TestMethod]        
        public void CanSetPositiveDrillingDepth()
        {
            Rig rig = new Rig();
            rig.DrillingDepth = 1;
        }

        [TestMethod]
        public void CanSetPositiveWaterDepth()
        {
            Rig rig = new Rig();
            rig.WaterDepth = 1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WillThrowExceptionOnBlankName()
        {
            Rig rig = new Rig();
            rig.Name = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WillThrowExceptionOnNegativeWaterDepth()
        {
            Rig rig = new Rig();
            rig.WaterDepth = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WillThrowExceptionOnNegativeDrillingDepth()
        {
            Rig rig = new Rig();
            rig.DrillingDepth = -1;
        }
    }
}
