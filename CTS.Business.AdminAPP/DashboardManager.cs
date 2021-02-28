using CTS.Business.AdminAPP.Interface;
using CTS.Common;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.Model;
using CTS.Model.DashBoard;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP
{
    public class DashboardManager : IDashboardManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardManager(IConfiguration config, IDashboardRepository dashboardRepository, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _dashboardRepository = dashboardRepository;
            this._httpContextAccessor = httpContextAccessor;
        }

        public DataSet GetDashboard(DashBoard reqObj)
        {
            DataSet gridDataSet = null;
            try
            {
                gridDataSet = _dashboardRepository.GetDashboard(reqObj);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return gridDataSet;
           
        }
    }
}
