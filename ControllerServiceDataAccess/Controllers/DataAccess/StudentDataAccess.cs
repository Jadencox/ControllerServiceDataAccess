using ControllerServiceDataAccess.Extensions;
using ControllerServiceDataAccess.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace ControllerServiceDataAccess.DataAccess
{
    public class StudentDataAccess: RepositoryBase<WorkStationDbContext>
    {
        public StudentDataAccess(WorkStationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {   
        }

        public bool InsertStu() 
        { 
            Student student = new Student();
            student.CreateTime = DateTime.Now;
            student.Name = $"朱{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            Random rnd = new Random();
            rnd.Next(1,100);
            student.Age = rnd.Next(1, 100);
            student.Id = Guid.NewGuid().ToString("N");
            DbContext.Student.Add(student);
            return DbContext.SaveChanges() > 0;
        } 
    }
}
