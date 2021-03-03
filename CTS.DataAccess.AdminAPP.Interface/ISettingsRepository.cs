using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface ISettingsRepository
    {
        DataSet GetSettings();

        bool AEDSettings(CrudModel input, int userid);
    }
}
