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
    public class EventsManager : IEventsManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly IEventsRepository _eventsRepository;
        public EventsManager(IConfiguration config, IEventsRepository eventsRepository, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _eventsRepository = eventsRepository;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<Dictionary<string, dynamic>> GetEvents(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _eventsRepository.GetEvents();

                Utility utility = new Utility(_httpContextAccessor);

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }

        public bool AEDEvents(CrudModel dataObj, int userid)
        {
            bool status = false;
            try
            {
                status = _eventsRepository.AEDEvents(dataObj, userid);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }
    }
}
