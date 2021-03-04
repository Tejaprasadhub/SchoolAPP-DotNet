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

        public bool AEDSettings(SettingsModel dataObj, int userid)
        {
            try
            {
                Utility utility = new Utility(_httpContextAccessor);

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@id",dataObj.id },
                    {"@sub_domain",utility.GetDatabasename(utility.GetSubdomain()).ToString()},
                    {"@tran_key",dataObj.tran_key },
                    {"@prom_key",dataObj.prom_key },
                    {"@sender_code",dataObj.sender_code },
                    {"@from_mail",dataObj.from_mail },
                    {"@from_mailpassword",dataObj.from_mailpassword },
                    {"@port",dataObj.port },
                    {"@vendor_type",dataObj.vendor_type },
                    {"@userid",dataObj.userid },
                    {"@password",dataObj.password },
                    {"@razor_api",dataObj.razor_api },
                    {"@razor_key",dataObj.razor_key },
                    {"@paypal_api",dataObj.paypal_api },
                    {"@paypal_key",dataObj.paypal_key  },
                    {"@querytype",dataObj.querytype }
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
