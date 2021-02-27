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
    class ParentsManager : IParentsManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly IParentsRepository _parentsRepository;
        public ParentsManager(IConfiguration config, IParentsRepository parentsRepository, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _parentsRepository = parentsRepository;
            this._httpContextAccessor = httpContextAccessor;
        }
        public async Task<Dictionary<string, dynamic>> GetParents(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _parentsRepository.GetParents(pagingParameters);

                Utility utility = new Utility(_httpContextAccessor);

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }
        public bool AEDParents(CrudModel dataObj, int userid)
        {
            bool status = false;
            try
            {
                status = _parentsRepository.AEDParents(dataObj, userid);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }
    }
}
