using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rigzone.DAL.Contract
{
    public interface IUnitOfWork
    {
        DataSet FillDataSet(string sqlCommand, bool proc);

        void ExecuteNonQuery(string sql, bool proc);

        int ExecuteScalar(string sql, bool proc);
    }
}
