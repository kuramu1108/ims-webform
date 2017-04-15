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
        List<T> ExecuteReader(SqlCommand command);

        int ExecuteNonQuery(SqlCommand command, T value);

        object ExecuteScalar(SqlCommand command, T value);
    }
}
