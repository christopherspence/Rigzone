using Rigzone.DAL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rigzone.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public System.Data.DataSet FillDataSet(string sqlCommand, bool proc)
        {
            throw new NotImplementedException();
        }

        public void ExecuteNonQuery(string sql, bool proc)
        {
            throw new NotImplementedException();
        }

        public int ExecuteScalar(string sql, bool proc)
        {
            throw new NotImplementedException();
        }
    }
}
