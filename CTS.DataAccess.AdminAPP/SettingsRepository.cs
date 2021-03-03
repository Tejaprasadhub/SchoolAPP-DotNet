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
   public class SettingsRepository : CTSRepositoryBase, ISettingsRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<SettingsRepository> _logger;
        public SettingsRepository(CTSContext db, ILogger<SettingsRepository> logger, IHttpContextAccessor httpContextAccessor)
        {
            this._db = db;
            this._logger = logger;
            this._httpContextAccessor = httpContextAccessor;
        }

        public DataSet GetSettings()
        {
            try
            {
                DataSet ds = new DataSet();
                Utility utility = new Utility(_httpContextAccessor);
                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@subdomain",utility.GetDatabasename(utility.GetSubdomain()) }
                };
                ds = _db.Execute("GetSettings", CommandType.StoredProcedure, parameters, "");

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AEDSettings(CrudModel dataObj, int userid)
        {
            try
            {
                Utility utility = new Utility(_httpContextAccessor);

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@id",dataObj.id },
                    {"@branchid",dataObj.branchid },
                    {"@name",dataObj.name },
                    {"@category",dataObj.category },
                    {"@description",dataObj.description },
                    {"@image",dataObj.image },
                    {"@accept_registrations",dataObj.register },
                    {"@startdate",dataObj.start },
                    {"@enddate",dataObj.end },
                    {"@url",dataObj.url },
                    {"@userid",userid },
                    {"@querytype",dataObj.querytype },
                    {"@status",dataObj.status }
                };

                _db.Execute("AEDSettings", CommandType.StoredProcedure, parameters, "");

                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
