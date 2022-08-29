using ControllerServiceDataAccess.Models;
using System.Collections.Generic;

namespace ControllerServiceDataAccess.IServices
{
     public interface IStudentService
     {
        List<Student> GetStudents();

        bool InsertStu(string str);
     }
}
