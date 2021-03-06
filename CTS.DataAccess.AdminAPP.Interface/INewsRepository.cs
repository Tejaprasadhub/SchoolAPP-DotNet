﻿using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface INewsRepository 
    {
        DataSet GetNews(GridParameters pagingParameters, UserProfile userProfile);
        bool AEDNews(CrudModel input, UserProfile userProfile);
    }
}
