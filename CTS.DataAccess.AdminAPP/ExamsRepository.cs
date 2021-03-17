using CTS.Common;
using CTS.Core.DataAccess;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.DataAccess.Core;
using CTS.Model;
using CTS.Model.Exams;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP
{
    public class ExamsRepository : CTSRepositoryBase, IExamsRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ExamsRepository> _logger;
        public ExamsRepository(CTSContext db, ILogger<ExamsRepository> logger, IHttpContextAccessor httpContextAccessor)
        {
            this._db = db;
            this._logger = logger;
            this._httpContextAccessor = httpContextAccessor;
        }

        public DataSet GetExams(GridParameters pagingParameters,UserProfile userProfile)
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

                ds = _db.Execute("GetExams", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AEDExams(ExamWiseSubjectsList dataObj, UserProfile userProfile,string title,string year,string status,string id, string querytype)
        {
            try
            {
                Utility utility = new Utility(_httpContextAccessor);

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@id",id },
                    {"@title",title },
                    {"@year",year },
                    {"@userid",userProfile.UserId },
                    {"@status",status },
                    {"@querytype",querytype },
                    {"@classId",dataObj.classid },
                    {"@subjectId",dataObj.subjectid },
                    {"@cutoff",dataObj.cutoff },
                    {"@total",dataObj.total },

                };

                _db.Execute("AEDExams", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public bool CheckExistsOrNot(Exams dataObj,string type)
        {
            try
            {
                Utility utility = new Utility(_httpContextAccessor);

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@title",dataObj.title },
                    {"@year",dataObj.year },
                    {"@type",type },
                };

               DataSet ds = _db.Execute("CheckExistsOrNot", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));
               
                if (ds.Tables[0].Rows.Count > 0)
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


        public bool DeleteExamwiseSubjects(string examid)
        {
            try
            {
                Utility utility = new Utility(_httpContextAccessor);

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@examid",examid}
                };

                DataSet ds = _db.Execute("DeleteExamwiseSubjects", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
