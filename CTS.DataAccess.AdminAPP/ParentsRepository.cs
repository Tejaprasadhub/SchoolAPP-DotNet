﻿using CTS.Common;
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
    public class ParentsRepository : CTSRepositoryBase, IParentsRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ParentsRepository> _logger;
        public ParentsRepository(CTSContext db, ILogger<ParentsRepository> logger, IHttpContextAccessor httpContextAccessor)
        {
            this._db = db;
            this._logger = logger;
            this._httpContextAccessor = httpContextAccessor;
        }

        public DataSet GetParents(GridParameters pagingParameters)
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

                ds = _db.Execute("GetParents", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AEDParents(CrudModel dataObj, UserProfile userProfile)
        {
            try
            {
                Utility utility = new Utility(_httpContextAccessor);

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@id",dataObj.id },
                    {"@fname",dataObj.fname },
                    {"@lname",dataObj.lname },
                      {"@mobile",dataObj.mobile },
                    {"@gender",dataObj.gender },
                      {"@email",dataObj.email },                    
                    {"@userid",userProfile.UserBranch },
                    {"@querytype",dataObj.querytype },
                     {"@status",dataObj.status }
                };

                DataSet ds = _db.Execute("AEDParents", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

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
