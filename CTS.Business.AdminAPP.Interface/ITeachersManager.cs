using CTS.Model;
using CTS.Model.Teachers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface ITeachersManager
    {
        Task<Dictionary<string, dynamic>> GetTeachers(GridParameters pagingParameters,UserProfile userProfile);
        bool AEDTeachers(createTeacher input,UserProfile userProfile);
    }
}
