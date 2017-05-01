using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataAccessInterfaces.Helpers;
using IMSDBLayer.DataModels;
using System.Data.SqlClient;

namespace IMSDBLayer.DataAccessObjects
{
    public class InterventionTypeDataAccess : IInterventionTypeDataAccess
    {
        private ISqlExecuter<InterventionType> sqlExecuter;

        public InterventionTypeDataAccess(ISqlExecuter<InterventionType> sqlExecuter)
        {
            this.sqlExecuter = sqlExecuter;
        }
        /// <summary>
        /// Get all intervention type
        /// </summary>
        /// <returns>A list of intervention type</returns>
        public IEnumerable<InterventionType> getAll()
        {
            SqlCommand command = new SqlCommand("Select * From InterventionTypes");
            return sqlExecuter.ExecuteReader(command);
        }
        /// <summary>
        /// Create an intervention type
        /// </summary>
        /// <param name="interventionType">Intervention type object</param>
        /// <returns>An intervention type object created</returns>
        public InterventionType create(InterventionType interventionType)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO InterventionTypes (Name, Hours, Costs) VALUES(@Name, @Hours, @Costs)");

            interventionType.Id = (Guid) sqlExecuter.ExecuteScalar(command, interventionType);
                if (interventionType.Id != Guid.Empty)
                    return interventionType;
                return null;
        }
        /// <summary>
        /// Update an intervention type 
        /// </summary>
        /// <param name="interventionType">Intervention type object</param>
        /// <returns>True if success, false if fail</returns>
        public bool update(InterventionType interventionType)
        {
            SqlCommand command = new SqlCommand(@"UPDATE InterventionTypes Set Name = @Name, Hours = @Hours, Costs = @Costs  WHERE Id = @Id");
            return sqlExecuter.ExecuteNonQuery(command, interventionType) > 0;
        }
        /// <summary>
        /// Get intervention type by it's id
        /// </summary>
        /// <param name="interventionTypeId">The guid of an intervention type</param>
        /// <returns>An intervention type object</returns>
        public InterventionType fetchInterventionTypesById(Guid interventionTypeId)
        {
            SqlCommand command = new SqlCommand(@"Select * From InterventionTypes Where Id = @Id");
            command.Parameters.AddWithValue("@Id", interventionTypeId);
            return sqlExecuter.ExecuteReader(command).FirstOrDefault();
        }

        
    }
}
