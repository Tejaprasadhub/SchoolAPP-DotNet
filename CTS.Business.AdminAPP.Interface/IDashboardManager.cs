﻿using CTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace CTS.Business.AdminAPP.Interface
{
    public interface IDashboardManager
    {
        Task<Dictionary<string, dynamic>> GetDashboard(GridParameters pagingParameters);
    }
}
