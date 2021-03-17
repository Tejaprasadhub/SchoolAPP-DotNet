using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IBranchesRepository
    {
        DataSet GetBranches(GridParameters pagingParameters, UserProfile userProfile);
        bool AEDBranches(CrudModel input,UserProfile userProfile);
    }
}
