﻿using IMSLogicLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSLogicLayer.Enums;
using IMSLogicLayer.Models;

namespace IMSLogicLayer.Services
{
    public class AccountantService : BaseService,IAccountantService
    {
        private Guid accoutantId;
        public AccountantService(string connstring) : base(connstring)
        {
        }
        /// <summary>
        /// Initialise accountant service 
        /// </summary>
        /// <param name="connstring">connection string to the database</param>
        /// <param name="identityId">identity id of an user</param>
        public AccountantService(string connstring, string identityId) : base(connstring)
        {
            this.accoutantId = new Guid(identityId);
        }
        /// <summary>
        /// Change district of an user
        /// </summary>
        /// <param name="userId">The guid of the user</param>
        /// <param name="districtId">The guid of the district</param>
        /// <returns>True if success, false if fail</returns>
        public bool changeDistrict(Guid userId, Guid districtId)
        {
            var user = getUserById(userId);
            user.DistrictId = districtId;
            return Users.updateUser(user);
        }
        /// <summary>
        /// Get all manager in the system
        /// </summary>
        /// <returns>A list of manager</returns>
        public IEnumerable<User> getAllManger()
        {
            return Users.fetchUsersByUserType((int)UserType.Manager).Select(c => new User(c)).ToList(); ;
        }
        /// <summary>
        /// Get all engineer in the system
        /// </summary>
        /// <returns>A list of engineer</returns>
        public IEnumerable<User> getAllSiteEngineer()
        {
            return Users.fetchUsersByUserType((int)UserType.SiteEngineer).Select(c => new User(c)).ToList();
        }
        /// <summary>
        /// Get all user in the system
        /// </summary>
        /// <returns>A list of user</returns>
        public IEnumerable<User> getAllUser()
        {
           return Users.getAll().Select(c => new User(c)).ToList();
        }
        /// <summary>
        /// Get the current user instance
        /// </summary>
        /// <returns>The current user instance</returns>
        public User getDetail()
        {
            return new User(Users.fetchUserByIdentityId(accoutantId));
        }
        /// <summary>
        /// Get the user with it's id
        /// </summary>
        /// <param name="userId">The guid of an user</param>
        /// <returns>An user instance</returns>
        public User getUserById(Guid userId)
        {
            return new User(Users.fetchUserById(userId));
        }
        /// <summary>
        /// Gets the report data for average cost by engineer report
        /// </summary>
        /// <returns>a list of reportrow to construct a report</returns>
        public IEnumerable<ReportRow> printAverageCostByEngineer()
        {
            return ReportDataAccess.averageCostByEngineer().Select(c => new ReportRow(c)).ToList();
        }
        /// <summary>
        /// Gets the report data for monthly cost by district report
        /// </summary>
        /// <returns>a list of reportrow to construct a report</returns>
        public IEnumerable<ReportRow> printMonthlyCostByDistrict(Guid districtId)
        {
            return ReportDataAccess.monthlyCostForDistrict(districtId).Select(c => new ReportRow(c)).ToList();
        }
        /// <summary>
        /// Gets the report data for total cost by district report
        /// </summary>
        /// <returns>a list of reportrow to construct a report</returns>
        public IEnumerable<ReportRow> printTotalCostByDistrict()
        {
            return ReportDataAccess.costByDistrict().Select(c => new ReportRow(c)).ToList();
        }
        /// <summary>
        /// Gets the report data for total cost by engineer report
        /// </summary>
        /// <returns>a list of reportrow to construct a report</returns>
        public IEnumerable<ReportRow> printTotalCostByEngineer()
        {
            return ReportDataAccess.totalCostByEngineer().Select(c => new ReportRow(c)).ToList();
        }
    }
}
