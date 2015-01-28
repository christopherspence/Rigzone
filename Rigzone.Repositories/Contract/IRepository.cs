using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rigzone.Repositories.Contract
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all objects
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get object with specific ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(Guid id);

        /// <summary>
        /// Add a new object to the db.
        /// </summary>
        /// <param name="item"></param>
        void Add(T item);

        /// <summary>
        /// Update an item in the db.
        /// </summary>
        /// <param name="item"></param>
        void Modify(T item);

        /// <summary>
        /// Delete an item from the db.
        /// </summary>
        /// <param name="item"></param>
        void Delete(T item);
    }
}
