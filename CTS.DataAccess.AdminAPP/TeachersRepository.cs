using CTS.Common;
using CTS.Core.DataAccess;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.DataAccess.Core;
using CTS.Model;
using CTS.Model.Teachers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP
{
    public class TeachersRepository : CTSRepositoryBase, ITeachersRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<TeachersRepository> _logger;
        public TeachersRepository(CTSContext db, ILogger<TeachersRepository> logger, IHttpContextAccessor httpContextAccessor)
        {
            this._db = db;
            this._logger = logger;
            this._httpContextAccessor = httpContextAccessor;
        }

        public DataSet GetTeachers(GridParameters pagingParameters,UserProfile userProfile)
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility(_httpContextAccessor);

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@queryType",pagingParameters.queryType },
                    {"@branchId",userProfile.UserBranch},
                    {"@idValue",pagingParameters.idValue }
                };

                ds = _db.Execute("GetTeachers", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AEDTeachers(createTeacher dataObj,UserProfile userProfile)
        {
            try
            {
                Utility utility = new Utility(_httpContextAccessor);

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@id",dataObj.id },
                    {"@teacherName",dataObj.teacherName },
                    {"@dateofbirth",dataObj.dateofbirth },
                    {"@qualifications",dataObj.qualifications },
                    {"@email",dataObj.email },
                     {"@mobile",dataObj.mobile },
                     {"@experience",dataObj.experience },
                     {"@subjects",dataObj.subjects },
                     {"@classes",dataObj.classes },
                     {"@sections",dataObj.sections },
                     {"@branch",dataObj.branch },
                     {"@gender",dataObj.gender },
                     {"@indexId",dataObj.indexId },
                     {"@status",dataObj.status },
                     {"@querytype",dataObj.querytype },
                     {"@userid",userProfile.UserId },
                     {"@LID",0 },

            };
                _db.Execute("AEDTeachers", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
