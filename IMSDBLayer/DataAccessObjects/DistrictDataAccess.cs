﻿using System;
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
    public class DistrictDataAccess : IDistrictDataAccess
    {
        private ISqlExecuter<District> sqlExecuter;

        public DistrictDataAccess(ISqlExecuter<District> sqlExecuter)
        {
            this.sqlExecuter = sqlExecuter;
        }
        /// <summary>
        /// Create a district
        /// </summary>
        /// <param name="district">district object</param>
        /// <returns>district object</returns>
        public District create(District district)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO Districts (Name) VALUES(@Name)");
            district.Id = (Guid)sqlExecuter.ExecuteScalar(command, district);

            if (district.Id != Guid.Empty)
                return district;
            return null;
        }
        /// <summary>
        /// Update a district
        /// </summary>
        /// <param name="district">district object</param>
        /// <returns>True if success, false if fail</returns>
        public bool update(District district)
        {
            SqlCommand command = new SqlCommand(@"UPDATE Districts Set Name = @Name WHERE Id = @Id");
            return sqlExecuter.ExecuteNonQuery(command, district) > 0;
        }
        /// <summary>
        /// Get all district
        /// </summary>
        /// <returns>A list of district</returns>
        public IEnumerable<District> getAll()
        {
            SqlCommand command = new SqlCommand("Select * From Districts");
            return sqlExecuter.ExecuteReader(command);
        }
        /// <summary>
        /// Get district by its' id
        /// </summary>
        /// <param name="districtId">the guid of a district</param>
        /// <returns>district object</returns>
        public District fetchDistrictById(Guid districtId)
        {
            SqlCommand command = new SqlCommand(@"Select * From Districts WHERE Id = @Id");
            command.Parameters.AddWithValue("@Id", districtId);
            return sqlExecuter.ExecuteReader(command).FirstOrDefault();
        }
        /// <summary>
        /// Get district by it's name
        /// </summary>
        /// <param name="name">the name of a district</param>
        /// <returns>district object</returns>
        public District fetchDistrictByName(string name)
        {
            SqlCommand command = new SqlCommand(@"Select * From Districts Where Name =@Name");
            command.Parameters.AddWithValue("@Name", name);
            return sqlExecuter.ExecuteReader(command).FirstOrDefault();
        }
    }
}
