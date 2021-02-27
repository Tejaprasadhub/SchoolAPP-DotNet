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

        public DataSet GetEvents()
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility(_httpContextAccessor);

                ds = _db.Execute("GetEvents", CommandType.StoredProcedure, null, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AEDEvents(CrudModel dataObj, int userid)
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
                    {"@accept_registrations",dataObj.accept_registrations },
                    {"@startdate",dataObj.startdate },
                    {"@enddate",dataObj.enddate },
                    {"@url",dataObj.url },
                    {"@userid",userid },
                    {"@querytype",dataObj.querytype }
                };

                _db.Execute("AEDEvents", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
