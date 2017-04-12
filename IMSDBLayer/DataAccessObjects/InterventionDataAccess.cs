using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataModels;
using IMSDBLayer.Enums;
using System.Data.SqlClient;

namespace IMSDBLayer.DataAccessObjects
{
    public class InterventionDataAccess : IInterventionDataAccess
    {
        private string connstring = "";

        public InterventionDataAccess(string connstring)
        {
            this.connstring = connstring;
        }

        public Intervention create(Intervention intervention)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO Interventions (Name, Type, MaxHoursCanApprove, 
                MaxCostsCanApprove, IdentityId, DistrictId) " + "VALUES(@name, @type, " +
                "@maxHoursCanApprove, @maxCostsCanApprove, @identityId, @districtId)");

            command.Parameters.Add(new SqlParameter("name", intervention.Hours));
            command.Parameters.Add(new SqlParameter("type", intervention.Costs));
            command.Parameters.Add(new SqlParameter("maxHoursCanApprove", intervention.LifeRemaining));
            command.Parameters.Add(new SqlParameter("maxCostsCanApprove", intervention.Comments));
            command.Parameters.Add(new SqlParameter("identityId", intervention.State));
            command.Parameters.Add(new SqlParameter("districtId", intervention.DateCreate));
            command.Parameters.Add(new SqlParameter("districtId", intervention.DateFinish));
            command.Parameters.Add(new SqlParameter("districtId", intervention.DateRecentVisit));
            command.Parameters.Add(new SqlParameter("districtId", intervention.InterventionTypeId));
            command.Parameters.Add(new SqlParameter("districtId", intervention.ClientId));
            command.Parameters.Add(new SqlParameter("districtId", intervention.CreatedBy));
            command.Parameters.Add(new SqlParameter("districtId", intervention.ApprovedBy));

            if (executeUpdateSqlCommand(command) == true)
                return intervention;
            return null;
        }

        public bool update(Intervention intervention)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Intervention> Interventions
        {
            get
            {
                SqlCommand command = new SqlCommand("Select * From Interventions");
                return executeReadSqlCommand(command);
            }
        }

        public Intervention fetchInterventionsById(Guid interventionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Intervention> fetchInterventionsByCreator(Guid creatorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Intervention> fetchInterventionsByDistrict(Guid districtId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Intervention> fetchInterventionsByState(InterventionState state)
        {
            throw new NotImplementedException();
        }

        private List<Intervention> executeReadSqlCommand(SqlCommand command)
        {
            List<Intervention> interventions = new List<Intervention>();
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Intervention intervention = new Intervention();
                    intervention.Id = reader.GetGuid(0);
                    intervention.Hours = reader.GetDecimal(0);
                    intervention.Costs = reader.GetDecimal(1);
                    intervention.LifeRemaining = reader.GetInt32(2);
                    intervention.Comments = reader.GetString(3);
                    intervention.State = (InterventionState)reader.GetInt32(4);
                    intervention.DateCreate = reader.GetDateTime(5);
                    intervention.DateFinish = reader.GetDateTime(6);
                    intervention.DateRecentVisit = reader.GetDateTime(7);
                    intervention.InterventionTypeId = reader.GetGuid(8);
                    intervention.ClientId = reader.GetGuid(9);
                    intervention.CreatedBy = reader.GetGuid(10);
                    intervention.ApprovedBy = reader.GetGuid(11);

                    interventions.Add(intervention);
                }
                connection.Close();
            }
            return interventions;
        }

        private bool executeUpdateSqlCommand(SqlCommand command)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //TODO - Implement low DB SQL excution exception logging.
                return false;
            }
            return true;
        }


    }
}
