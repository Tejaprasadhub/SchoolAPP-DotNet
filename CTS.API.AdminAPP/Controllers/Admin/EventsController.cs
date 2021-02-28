using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CTS.Business.AdminAPP.Interface;
using CTS.Model;
using CTS.Model.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CTS.API.AdminAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly IEventsManager _eventsManager;
        public EventsController(IConfiguration config, IEventsManager eventsManager)
        {
            _config = config;
            _eventsManager = eventsManager;
        }

        [HttpPost("GetEvents")]
        public async Task<ActionResult> GetEvents([FromBody] Events reqObj)
        {
            DataSet ds = new DataSet();

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();

            try
            {

                 ds =  _eventsManager.GetEvents(reqObj);

                //returnObj.Add("data", ds.Tables[0]);

                return Ok(new { success = true,  data=ds.Tables[0] });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("AEDEvents")]
        public async Task<ActionResult> AEDEvents([FromBody] CrudModel dataObj)
        {
            //var userProfile = GetUserProfile();
            try
            {
                bool status = _eventsManager.AEDEvents(dataObj, 1);


                return Ok(new { success = status });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
