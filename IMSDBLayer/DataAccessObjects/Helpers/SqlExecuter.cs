using IMSDBLayer.DataAccessInterfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IMSDBLayer.DataAccessObjects.Helpers
{
    public class SqlExecuter<T> : ISqlExecuter<T>
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
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                command.Connection = connection;
                command = setSqlCommandParameters(command, value);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(SqlCommand command, T value)
        {
            using (SqlConnection connection = new SqlConnection(connstring))
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
                var propertyRegex = @"[^\w]" + propertyParameter + @"([^\w]|$)";
                
                if (Regex.Matches(command.CommandText, propertyRegex).Count > 0)
                {
                    if (property.GetValue(value) == null)
                    {
                        command.Parameters.AddWithValue(propertyParameter, DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue(propertyParameter, property.GetValue(value));
                    }
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

                //check if property is nullable type
                bool isNullableType = property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>);
                //check if property can contain null value
                bool isNullable = isNullableType || property.PropertyType.IsValueType == false;
                //get property underlying type
                string propertyTypeName = isNullableType ? property.PropertyType.GetGenericArguments()[0].UnderlyingSystemType.Name : property.PropertyType.Name;
                //check if data column return null
                bool isDataNull = reader.IsDBNull(i);

                if (isDataNull)
                {
                    if (isNullable)
                    {
                        property.SetValue(result, null);
                    }
                    else
                    {
                        var defaultValue = Activator.CreateInstance(property.PropertyType);
                        property.SetValue(result, defaultValue);
                    }
                }
                else
                {
                    switch (propertyTypeName)
                    {
                        case "Guid": property.SetValue(result, reader.GetGuid(i)); break;
                        case "String": property.SetValue(result, reader.GetString(i), null); break;
                        case "Int32": property.SetValue(result, reader.GetInt32(i), null); break;
                        case "DateTime": property.SetValue(result, reader.GetDateTime(i)); break;
                        case "Decimal": property.SetValue(result, reader.GetDecimal(i), null); break;
                        default: throw new Exception("Unknow Type: " + property.PropertyType.Name);
                    }
                }
            }
            return result;
        }
    }
}
