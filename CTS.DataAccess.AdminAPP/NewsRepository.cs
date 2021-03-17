using CTS.Common;
using CTS.Core.DataAccess;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.DataAccess.Core;
using CTS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP
{
    public class NewsRepository : CTSRepositoryBase, INewsRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<TeachersRepository> _logger;
        public NewsRepository(CTSContext db, ILogger<TeachersRepository> logger, IHttpContextAccessor httpContextAccessor)
        {
            this._db = db;
            this._logger = logger;
            this._httpContextAccessor = httpContextAccessor;
        }

        public DataSet GetNews(GridParameters pagingParameters, UserProfile userProfile)
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility(_httpContextAccessor);
                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@queryType",pagingParameters.queryType },
                    {"@branchId",userProfile.UserBranch },
                    {"@idValue",pagingParameters.idValue }
                };

                ds = _db.Execute("GetNews", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AEDNews(CrudModel dataObj, UserProfile userProfile)
        {
            try
            {
                Utility utility = new Utility(_httpContextAccessor);

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@id",dataObj.id },
                    {"@branchid",dataObj.branchid },
                    {"@title",dataObj.title },
                    {"@date",dataObj.date },
                    {"@description",dataObj.description },
                    {"@userid",userProfile.UserId },
                    {"@querytype",dataObj.querytype },
                    {"@status",dataObj.status }
                };

                DataSet ds = _db.Execute("AEDNews", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                if (dataObj.querytype == 1 && ds.Tables[0].Rows.Count > 0)
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
