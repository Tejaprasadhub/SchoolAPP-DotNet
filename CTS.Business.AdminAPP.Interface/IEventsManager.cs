using CTS.Model;
using CTS.Model.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface IEventsManager
    {
        DataSet GetEvents(Events reqObj);
        bool AEDEvents(CrudModel input, int userid);
    }
}
