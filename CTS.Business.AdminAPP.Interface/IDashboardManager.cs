using CTS.Model;
using CTS.Model.DashBoard;
using System.Data;


namespace CTS.Business.AdminAPP.Interface
{
    public interface IDashboardManager
    {
        DataSet GetDashboard(DashBoard reqObj, UserProfile userProfile);
    }
}
