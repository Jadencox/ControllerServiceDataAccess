using ControllerServiceDataAccess.Models;
using System.Collections.Generic;

namespace ControllerServiceDataAccess.IServices
{
    public interface IUserService
    {
        List<SysUser> GetSysUsers();

        List<Student> GetStudents();
    }
}
