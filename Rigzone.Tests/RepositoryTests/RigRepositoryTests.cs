using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rigzone.DAL.Contract;
using Rigzone.Models;
using Rigzone.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rigzone.Common.Extensions;
using Rigzone.Repositories;

namespace Rigzone.Tests.RepositoryTests
{
    [TestClass]
    public class RigRepositoryTests
    {
        private DataSet dataSet = new DataSet();
        private IRigRepository repo;

        [TestInitialize]
        public void Setup()
        {
            // Fill up some fake data so we have something to test against.
            DataTable rigsTable = new DataTable("Rigs");
            rigsTable.Columns.Add("RigID", typeof(Guid));
            rigsTable.Columns.Add("RigName", typeof(string));
            rigsTable.Columns.Add("RigTypeID", typeof(Guid));
            rigsTable.Columns.Add("RigTypeName", typeof(string));
            rigsTable.Columns.Add("WaterDepth", typeof(int));
            rigsTable.Columns.Add("DrillingDepth", typeof(int));
            rigsTable.Columns.Add("ManagerID", typeof(Guid));
            rigsTable.Columns.Add("ManagerName", typeof(string));
            rigsTable.Columns.Add("RegionID", typeof(Guid));
            rigsTable.Columns.Add("RegionName", typeof(string));
            rigsTable.Columns.Add("CountryID", typeof(Guid));
            rigsTable.Columns.Add("CountryName", typeof(string));
            rigsTable.Columns.Add("CurrentBlockOrWell", typeof(string));
            rigsTable.Columns.Add("CurrentStartDate", typeof(string));
            rigsTable.Columns.Add("CurrentEndDate", typeof(string));

            rigsTable.Rows.Add(new Guid("B5E6B43D-C403-493C-8CA9-6A728F20DA45"),	
                "West Atlas", 
                "F3B55807-69CE-420B-85B8-57956B6658E1",
                "Jackup",
                400, 
                30000, 
                new Guid("819813E2-0B5D-40EA-BF3D-29534F2E4BB0"),
                "Seadrill Ltd",
                new Guid("51921FF9-5DDA-4F46-B720-329BE71F9A67"),
                "Australia",
                new Guid("431B905E-E99A-4D3A-9A72-F6C64DA922F9"),
                "Australia",
                null,
                DateTime.Parse("1/4/2013"),
                DateTime.Parse("11/3/2013"));

            dataSet.Tables.Add(rigsTable);

            // set up the mock repo
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.FillDataSet(It.IsAny<string>(), It.IsAny<bool>())).Returns(dataSet);
            repo = new RigRepository(mockUnitOfWork.Object);
        }

        [TestMethod]
        public void CanGetAllRigs()
        {
            List<Rig> rigs = repo.GetAll().ToList();
            Rig rig = rigs.First();

            Assert.IsTrue(rigs.Count == 1);
            DataRow row = dataSet.Tables[0].Rows[0];

            // Check to make sure all the data in the hydrated Rig class matches the datarow values.
            Assert.AreEqual(rig.ID, row.AsGuid("RigID"));
            Assert.AreEqual(rig.Name, row.AsString("RigName"));
            Assert.AreEqual(rig.RigType.ID, row.AsGuid("RigTypeID"));
            Assert.AreEqual(rig.RigType.Name, row.AsString("RigTypeName"));
            Assert.AreEqual(rig.WaterDepth, row.AsInt("WaterDepth"));
            Assert.AreEqual(rig.DrillingDepth, row.AsInt("DrillingDepth"));
            Assert.AreEqual(rig.Manager.ID, row.AsGuid("ManagerID"));
            Assert.AreEqual(rig.Manager.Name, row.AsString("ManagerName"));
            Assert.AreEqual(rig.CurrentLocation.Region.ID, row.AsGuid("RegionID"));
            Assert.AreEqual(rig.CurrentLocation.Region.Name, row.AsString("RegionName"));
            Assert.AreEqual(rig.CurrentLocation.Country.ID, row.AsGuid("CountryID"));
            Assert.AreEqual(rig.CurrentLocation.Country.Name, row.AsString("CountryName"));
            Assert.AreEqual(rig.CurrentLocation.BlockOrWell, row.AsString("CurrentBlockOrWell"));
            Assert.AreEqual(rig.CurrentLocation.StartDate, row.AsDate("CurrentStartDate"));
            Assert.AreEqual(rig.CurrentLocation.EndDate, row.AsNullableDate("CurrentEndDate"));
        }
    }
}
