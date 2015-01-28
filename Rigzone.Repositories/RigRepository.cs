using Rigzone.Models;
using Rigzone.Repositories.Contract;
using Rigzone.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rigzone.DAL.Contract;

namespace Rigzone.Repositories
{
    public class RigRepository : BaseRepository, IRigRepository
    {
        public RigRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IEnumerable<Rig> GetAll()
        {
            List<Rig> rigs = new List<Rig>();

            // Get data from db.
            DataSet ds = UnitOfWork.FillDataSet("EXEC GetRigs", true);           

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                rigs.Add(new Rig
                {
                    ID = row.AsGuid("RigID"),
                    Name = row.AsString("RigName"),
                    RigType = new RigType
                    {
                        ID = row.AsGuid("RigTypeID"),
                        Name = row.AsString("RigTypeName")
                        //SortOrder = row.AsInt("SortOrder") // Doesn't come back in proc
                    },
                    DrillingDepth = row.AsInt("DrillingDepth"),
                    WaterDepth = row.AsInt("WaterDepth"),
                    Manager = new Organization
                    {
                        ID = row.AsGuid("ManagerID"),
                        Name = row.AsString("ManagerName")                        
                    },
                    CurrentLocation = new Location
                    {
                        Region = new Region 
                        { 
                            ID = row.AsGuid("RegionID"),
                            Name = row.AsString("RegionName")                                                       
                        },
                        Country = new Country
                        {
                            ID = row.AsGuid("CountryID"),
                            Name = row.AsString("CountryName")
                        },
                        BlockOrWell = row.AsString("CurrentBlockOrWell"),
                        StartDate = row.AsDate("CurrentStartDate"),
                        EndDate = row.AsNullableDate("CurrentEndDate")
                    }
                });
            }

            return rigs;
        }

        public Rig Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Add(Rig item)
        {
            throw new NotImplementedException();
        }

        public void Modify(Rig item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Rig item)
        {
            throw new NotImplementedException();
        }
    }
}
