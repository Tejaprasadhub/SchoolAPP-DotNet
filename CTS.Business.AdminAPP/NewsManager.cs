using CTS.Business.AdminAPP.Interface;
using CTS.Common;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
namespace CTS.Business.AdminAPP
{
    public class NewsManager : INewsManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly INewsRepository _newsRepository;
        public NewsManager(IConfiguration config, INewsRepository newsRepository, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _newsRepository = newsRepository;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<Dictionary<string, dynamic>> GetNews(GridParameters pagingParameters,UserProfile userProfile)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _newsRepository.GetNews(pagingParameters,userProfile);

                Utility utility = new Utility(_httpContextAccessor);

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }

        public bool AEDNews(CrudModel dataObj, UserProfile userProfile)
        {
            bool status = false;
            try
            {
                status = _newsRepository.AEDNews(dataObj, userProfile);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }
    }
}
