using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.Business.AdminAPP.Interface
{
    public interface IDropdownManager
    {
        DataTable GetDropdowns(string spName,UserProfile userProfile);
        DataTable GetMenuOptions();
    }
}
