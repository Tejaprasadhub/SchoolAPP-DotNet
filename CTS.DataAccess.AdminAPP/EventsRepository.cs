using CTS.Common;
using CTS.Core.DataAccess;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.DataAccess.Core;
using CTS.Model;
using CTS.Model.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace CTS.DataAccess.AdminAPP
{
   public class EventsRepository : CTSRepositoryBase,IEventsRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<EventsRepository> _logger;
        public EventsRepository(CTSContext db, ILogger<EventsRepository> logger, IHttpContextAccessor httpContextAccessor)
        {
            this._db = db;
            this._logger = logger;
            this._httpContextAccessor = httpContextAccessor;
        }

        public DataSet GetEvents(Events reqObj, UserProfile userProfile)
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility(_httpContextAccessor);
                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@startdate",reqObj.start },
                    {"@enddate",reqObj.end },
                    {"@queryType",reqObj.querytype },
                    {"@branchId",userProfile.UserBranch },
                    {"@idValue",reqObj.id }
                };

                ds = _db.Execute("GetEvents", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AEDEvents(CrudModel dataObj, UserProfile userProfile)
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
                    {"@userid",userProfile.UserId },
                    {"@querytype",dataObj.querytype },
                    {"@status",dataObj.status } 
                };

                DataSet ds=_db.Execute("AEDEvents", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

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
