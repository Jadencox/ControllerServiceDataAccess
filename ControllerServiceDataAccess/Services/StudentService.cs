using ControllerServiceDataAccess.DataAccess;
using ControllerServiceDataAccess.Extensions;
using ControllerServiceDataAccess.IServices;
using ControllerServiceDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControllerServiceDataAccess.Services
{
    public class StudentService: ServiceBase<StudentDataAccess>,IStudentService
    {
        public StudentService(IServiceProvider serviceProvider, StudentDataAccess da): base(da, serviceProvider)
        {
        }

        public List<Student> GetStudents() 
        {
            var query = DataAccess.DbContext.Student.ToList();
            return query.ToList();
        }

        public bool InsertStu(string str)
        {
            var count = DataAccess.InsertStu();
            return count;
        }
    }
}
