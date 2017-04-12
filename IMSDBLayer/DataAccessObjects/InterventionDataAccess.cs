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

        public IEnumerable<Intervention> Interventions => throw new NotImplementedException();

        public Intervention create(Intervention intervention)
        {
            throw new NotImplementedException();
        }

        public bool update(Intervention intervention)
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
