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
   public class ClassesManager : IClassesManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly IClassesRepository _classesRepository;
        public ClassesManager(IConfiguration config, IClassesRepository classesRepository, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _classesRepository = classesRepository;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<Dictionary<string, dynamic>> GetClasses(GridParameters pagingParameters, UserProfile userProfile)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _classesRepository.GetClasses(pagingParameters,userProfile);

                Utility utility = new Utility(_httpContextAccessor);

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }

        public bool AEDClasses(CrudModel dataObj, UserProfile userProfile)
        {
            bool status = false;
            try
            {
                status = _classesRepository.AEDClasses(dataObj, userProfile);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }
    }
}
