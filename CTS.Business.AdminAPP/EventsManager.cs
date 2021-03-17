using CTS.Business.AdminAPP.Interface;
using CTS.Common;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.Model;
using CTS.Model.Events;
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

        public  DataSet GetEvents(Events reqObj,UserProfile userProfile)
        {

            DataSet gridDataSet = null;

            try
            {

                gridDataSet = _eventsRepository.GetEvents(reqObj, userProfile);                

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return gridDataSet;
        }

        public bool AEDEvents(CrudModel dataObj, UserProfile userProfile)
        {
            bool status = false;
            try
            {
                status = _eventsRepository.AEDEvents(dataObj, userProfile);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }
    }
}
