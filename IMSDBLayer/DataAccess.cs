using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer
{
    public class DataAccess
    {
        public  static void getUser(object userId)
        {

            string connstring = "";
            SqlConnection connection = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("Select * From Users Where UserID = @userID",connection);
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
            string connstring = "";
            SqlConnection connection = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("Select * From Users Where UserType = @userManager OR UserType = @userSiteEngineer",connection);
            cmd.Parameters.AddWithValue("userManager", "Manager");
            cmd.Parameters.AddWithValue("userSiteEngineer", "SiteEngineer");
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            throw new NotImplementedException();


        }

        public static void GetListofProposedInterventions()
        {
            string connstring = "";
            SqlConnection connection = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("Select * From Interventions Where State = @state", connection);
            cmd.Parameters.AddWithValue("state", "Proposed");
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
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

        public static void CreateClient(string name, string location, string district)
        {
            string connstring = "";
            SqlConnection connection = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("Insert Into Users (Name,Location,District) Values(@name,@location,@district)",connection);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("location", location);
            cmd.Parameters.AddWithValue("district", district);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            throw new NotImplementedException();
        }

        public static void ViewAllClient()
        {
            string connstring = "";
            SqlConnection connection = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("Select * From Client");

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            throw new NotImplementedException(); 
        }
        
        public static void GetClient(int clientid)

        {
            string connstring = "";
            SqlConnection connection = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("Select * From Client Where ID = @id");
            cmd.Parameters.AddWithValue("id", clientid);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            throw new NotImplementedException();
        }

        public static void GetIntervention(int clientid)
        {
            string connstring = "";
            SqlConnection connection = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("Select * From Intervention Where ClientID = @id");
            cmd.Parameters.AddWithValue("id", clientid);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            throw new NotImplementedException();
        }
        public static void viewOwnInterventions(int userID)
        {
            string connstring = "";
            SqlConnection connection = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("Select * From Intervention Where UserID = @id");
            cmd.Parameters.AddWithValue("id", userID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            throw new NotImplementedException();
        }

        public static void ChangeState(int interventionID, string newState)
        {
            string connstring = "";
            SqlConnection connection = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("UPDATE Intervention Set InterventionState = @newstate where ID= @id");
            cmd.Parameters.AddWithValue("id", interventionID);
            cmd.Parameters.AddWithValue("newstate", newState);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            throw new NotImplementedException();
        }

        public static void ChangeInterventionQuality(int interventionID, string comments, string remainLife, string date)
        {
            string connstring = "";
            SqlConnection connection = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("UPDATE Intervention Set Comments = @comments, LiftRemaining = @remainLife,DateRecentVisit = @date where ID= @id");
            cmd.Parameters.AddWithValue("id", interventionID);
            cmd.Parameters.AddWithValue("comments",comments);
            cmd.Parameters.AddWithValue("remailLife", remainLife);
            cmd.Parameters.AddWithValue("date", date);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            throw new NotImplementedException();
        }


        public static void PrintTotalCostByEngineerReport(int id)
        {
            

        }
    }
}
