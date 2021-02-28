using CTS.Model;
using CTS.Model.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IEventsRepository
    {
        DataSet GetEvents(Events reqObj);
        bool AEDEvents(CrudModel input, int userid);
    }
}
