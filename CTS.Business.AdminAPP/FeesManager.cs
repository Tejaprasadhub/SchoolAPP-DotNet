﻿using CTS.Business.AdminAPP.Interface;
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
    public class FeesManager : IFeesManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly IFeesRepository _feesRepository;
        public FeesManager(IConfiguration config, IFeesRepository feesRepository, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _feesRepository = feesRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Dictionary<string, dynamic>> GetFees(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _feesRepository.GetFees();

                Utility utility = new Utility(_httpContextAccessor);

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }
    }
}
