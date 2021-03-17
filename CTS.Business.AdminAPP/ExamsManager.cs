using CTS.Business.AdminAPP.Interface;
using CTS.Common;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.Model;
using CTS.Model.Exams;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP
{
    public class ExamsManager : IExamsManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly IExamsRepository _examsRepository;
        public ExamsManager(IConfiguration config, IExamsRepository examsRepository, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _examsRepository = examsRepository;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<Dictionary<string, dynamic>> GetExams(GridParameters pagingParameters, UserProfile userProfile)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _examsRepository.GetExams(pagingParameters,userProfile);

                Utility utility = new Utility(_httpContextAccessor);

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters, "GetExams");

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }

        public bool AEDExams(ExamWiseSubjectsList dataObj, UserProfile userProfile,string title,string year,string estatus,string id,string querytype)
        {
            bool status = false;
            try
            {
                status = _examsRepository.AEDExams(dataObj, userProfile,title,year, estatus,id,querytype);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }

        public bool CheckExistsOrNot(Exams dataObj,string type)
        {
            bool status = false;
            try
            {
                status = _examsRepository.CheckExistsOrNot(dataObj, type);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }



        public bool DeleteExamwiseSubjects(string examid)
        {
            bool status = false;
            try
            {
                status = _examsRepository.DeleteExamwiseSubjects(examid);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }
    }
}
