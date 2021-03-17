using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IAchievementsRepository
    {
         DataSet GetAchievement(GridParameters pagingParameters, UserProfile userProfile);
        bool AEDAchievements(CrudModel input, UserProfile userProfile);
    }
}
