using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CTS.Business.AdminAPP.Interface;
using CTS.Common;
using CTS.Model;
using CTS.Model.DashBoard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CTS.API.AdminAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ApiController
    {

        private readonly IConfiguration _config;
        private readonly IDashboardManager _dashboardManager;
        public DashboardController(IConfiguration config, IDashboardManager dashboardManager)
        {
            _config = config;
            _dashboardManager = dashboardManager;
        }

        [HttpPost("GetDashboard")]
        public async Task<ActionResult> GetDashboard([FromBody] DashBoard reqObj)
        {

            DataSet ds = new DataSet();

            try
            {
                ds =  _dashboardManager.GetDashboard(reqObj, GetUserProfile());

                return Ok(new { success = true, data = ds });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
