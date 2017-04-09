using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer
{
    public class GetData
    {
        public static void getUser(object userId)
        {

            string connstring = "";
            SqlConnection connection = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("Select * From Users Where UserID = @userID");
            cmd.Parameters.AddWithValue("userId", userId);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> userAttribute = new List<string>();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    userAttribute.Add(reader.GetString(i));
                }
            }
            connection.Close();
            //return userAttribute;
        }

        public static void getAllSGAndManger()
        {
            throw new NotImplementedException();
        }

        public static void GetListofProposedInterventions()
        {
            throw new NotImplementedException();
        }

        public static void ChangeDistricts(int userID, string newDistricts)
        {
            string connstring = "";
            SqlConnection connection = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("UPDATE Users SET Districts = @newDistricts Where UserID = @userID");
            cmd.Parameters.AddWithValue("userId", userID);
            cmd.Parameters.AddWithValue("Districts", newDistricts);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }
    }
}
