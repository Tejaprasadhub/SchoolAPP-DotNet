using CTS.Model;
using CTS.Model.Teachers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface ITeachersRepository
    {
        DataSet GetTeachers(GridParameters pagingParameters,UserProfile userProfile);
        bool AEDTeachers(createTeacher input,UserProfile userProfile);
    }
}
