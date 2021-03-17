using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface  IBrnachesManager
    {
        Task<Dictionary<string, dynamic>> GetBranches(GridParameters pagingParameters, UserProfile userProfile);
        bool AEDBranches(CrudModel input, UserProfile userProfile);
    }
}
