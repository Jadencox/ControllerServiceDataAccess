using ControllerServiceDataAccess.Extensions;
using ControllerServiceDataAccess.IServices;
using ControllerServiceDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControllerServiceDataAccess.Services
{
    public class UserService: ServiceBase, IUserService
    {
        public WorkStationDbContext _workStationDbContext;

        public UserService(WorkStationDbContext workStationDbContext,IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _workStationDbContext = workStationDbContext;
        }

        public List<SysUser> GetSysUsers()
        {
            var query = _workStationDbContext.SysUser.ToList();
            return query.ToList();
        }

        public List<Student> GetStudents()
        {
            var query = GetService<IStudentService>().GetStudents();
            return query.ToList();
        }
    }
}
