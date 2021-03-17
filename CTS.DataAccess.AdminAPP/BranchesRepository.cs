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
    public class BranchesRepository : CTSRepositoryBase, IBranchesRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<BranchesRepository> _logger;
        public BranchesRepository(CTSContext db, ILogger<BranchesRepository> logger, IHttpContextAccessor httpContextAccessor)
        {
            this._db = db;
            this._logger = logger;
            this._httpContextAccessor = httpContextAccessor;
        }

        public DataSet GetBranches(GridParameters pagingParameters, UserProfile userProfile)
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility(_httpContextAccessor);

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@queryType",pagingParameters.queryType },
                    {"@idValue",pagingParameters.idValue }
                };

                ds = _db.Execute("GetBranches", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));
                
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AEDBranches(CrudModel dataObj, UserProfile userProfile)
        {
            try
            {
                Utility utility = new Utility(_httpContextAccessor);

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@id",dataObj.id },
                    {"@code",dataObj.code },
                    {"@title",dataObj.title },
                    {"@userid",userProfile.UserId },
                    {"@querytype",dataObj.querytype },
                     {"@status",dataObj.status }
                };

              DataSet ds =  _db.Execute("AEDBranches", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                if(dataObj.querytype == 1 && ds.Tables[0].Rows.Count > 0)
                {
                    return false;
                }
                return true;

            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
