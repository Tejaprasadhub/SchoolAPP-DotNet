using CTS.Common;
using CTS.Core.DataAccess;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.DataAccess.Core;
using CTS.Model;
using CTS.Model.DashBoard;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CTS.DataAccess.AdminAPP
{
   public class DashboardRepository : CTSRepositoryBase, IDashboardRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<DashboardRepository> _logger;
        public DashboardRepository(CTSContext db, ILogger<DashboardRepository> logger, IHttpContextAccessor httpContextAccessor)
        {
            this._db = db;
            this._logger = logger;
            this._httpContextAccessor = httpContextAccessor;
        }

        public DataSet GetDashboard(DashBoard reqObj, UserProfile userProfile)
        {
            try
            {
                DataSet ds = new DataSet();
                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@startdate",reqObj.start },
                    {"@enddate",reqObj.end },
                    {"@chartType",reqObj.ChartType },
                    {"@branchId",userProfile.UserBranch }
                };

                Utility utility = new Utility(_httpContextAccessor);

                ds = _db.Execute("GetDashboard", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
