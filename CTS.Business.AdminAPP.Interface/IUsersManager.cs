using CTS.Common;
using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface IUsersManager
    {
        Task<Dictionary<string, dynamic>> GetUsers(GridParameters pagingParameters, UserProfile userProfile);
        bool AEDUsers(CrudModel input, UserProfile userProfile);

        AuthorizationResult AuthorizeComponentAccess(string routeUrl, UserProfile userProfile);
        DataTable permissionsOnComponent(string routeUrl, UserProfile userProfile);
    }
}
