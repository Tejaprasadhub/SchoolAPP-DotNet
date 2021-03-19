using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IUsersRepository
    {
        DataSet GetUsers(GridParameters pagingParameters,UserProfile userProfile);
        bool AEDUsers(CrudModel input, UserProfile userProfile);
        DataSet AuthorizeComponentAccess(string routeUrl, UserProfile userProfile);
        DataSet permissionsOnComponent(string routeUrl, UserProfile userProfile);
    }
}
