﻿using CTS.Model;
using CTS.Model.DashBoard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IDashboardRepository
    {
        DataSet GetDashboard(DashBoard reqObj,UserProfile userProfile );

    }
}
