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
   public class UsersManager : IUsersManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly IUsersRepository _usersRepository;
        public UsersManager(IConfiguration config, IUsersRepository usersRepository, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _usersRepository = usersRepository;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<Dictionary<string, dynamic>> GetUsers(GridParameters pagingParameters, UserProfile userProfile)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _usersRepository.GetUsers(pagingParameters,userProfile);

                Utility utility = new Utility(_httpContextAccessor);

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }

        public bool AEDUsers(CrudModel dataObj, UserProfile userProfile)
        {
            bool status = false;
            try
            {
                status = _usersRepository.AEDUsers(dataObj, userProfile);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }

        public AuthorizationResult AuthorizeComponentAccess(string routeUrl, UserProfile userProfile)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = _usersRepository.AuthorizeComponentAccess(routeUrl, userProfile);

                AuthorizationResult authorizationResult = new AuthorizationResult();
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        authorizationResult.status = dr["status"].ToString();
                        //authorizationResult.featureOptions.Add(dr["options"].ToString());
                    }
                }
                return authorizationResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable permissionsOnComponent(string routeUrl, UserProfile userProfile)
        {

            DataSet gridDataSet = null;

            DataTable dt = null;
            try
            {

                gridDataSet = _usersRepository.permissionsOnComponent(routeUrl,userProfile);

                dt = gridDataSet.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }

}
