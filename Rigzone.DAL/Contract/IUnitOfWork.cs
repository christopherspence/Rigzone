using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rigzone.DAL.Contract
{
    /// <summary>
    /// The default unit of work. Ideally these methods would be more generic, so we could have an ADOUnitOfWork, EFUnitOfWork, ServiceUnitOfWork, 
    /// but since the repo is ADO.NET specific, and there are no service requirements, we're sticking with ADO.NET-specific methods.
    /// </summary>
    public interface IUnitOfWork
    {

        DataSet FillDataSet(string sqlCommand, bool proc);

        void ExecuteNonQuery(string sql, bool proc);

        int ExecuteScalar(string sql, bool proc);
    }
}
