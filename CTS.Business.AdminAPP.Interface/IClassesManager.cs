using CTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface IClassesManager
    {
        Task<Dictionary<string, dynamic>> GetClasses(GridParameters pagingParameters, UserProfile userProfile);
        bool AEDClasses(CrudModel input, UserProfile userProfile);
    }
}
