using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer.DataAccessObjects.Helpers
{
    public class SqlExecuter<T>
    {
        private string connstring;

        public SqlExecuter (string connstring)
        {
            this.connstring = connstring;
        }

        public List<T> ExecuteReader(SqlCommand command)
        {
            List<T> results = new List<T>();
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(getReaderDataRow(reader));
                }
                connection.Close();
            }
            return results;
        }

        public int ExecuteNonQuery(SqlCommand command, T value)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                command.Connection = connection;
                command = setSqlCommandParameters(command, value);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(SqlCommand command, T value)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                command.Connection = connection;
                command = setSqlCommandParameters(command, value);
                connection.Open();
                return command.ExecuteScalar();
            }
        }

        private SqlCommand setSqlCommandParameters(SqlCommand command, T value)
        {
            var properties = value.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
                var propertyParameter = "@" + property.Name;
                if (command.CommandText.Contains(propertyParameter))
                {
                    command.Parameters.AddWithValue(propertyParameter, property.GetValue(value));
                }   
            }
            return command;
        }

        private T getReaderDataRow(SqlDataReader reader)
        {
            T result = (T)Activator.CreateInstance(typeof(T));
            var properties = result.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
                switch (property.PropertyType.Name)
                {
                    case "Guid": property.SetValue(typeof(Guid), reader.GetGuid(i)); break;
                    case "String": property.SetValue(typeof(String), reader.GetString(i)); break;
                    case "Int32": property.SetValue(typeof(Int32), reader.GetInt32(i)); break;
                    case "DateTime": property.SetValue(typeof(DateTime), reader.GetDateTime(i)); break;
                    case "Decimal": property.SetValue(typeof(Decimal), reader.GetDecimal(i)); break;
                    default: throw new Exception("Unknow Type: " + property.PropertyType.Name);
                }
            }
            return result;
        }
    }
}
