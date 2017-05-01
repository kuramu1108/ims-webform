using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer.DataAccessInterfaces.Helpers
{
    public interface ISqlExecuter <T>
    {

        /// <summary>
        /// Execute the sql command and return the results
        /// </summary>
        /// <param name="command">sql command</param>
        /// <returns>List of objects</returns>
        List<T> ExecuteReader(SqlCommand command);
        /// <summary>
        /// Execute the sql command and return the row effected
        /// </summary>
        /// <param name="command">sql command</param>
        /// <param name="value">object</param>
        /// <returns>rows effected</returns>
        int ExecuteNonQuery(SqlCommand command, T value);
        /// <summary>
        /// Execute the sql command and return one object
        /// </summary>
        /// <param name="command">sql command</param>
        /// <param name="value">object</param>
        /// <returns>An obejct</returns>
        object ExecuteScalar(SqlCommand command, T value);
    }
}
