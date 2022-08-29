using ControllerServiceDataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ControllerServiceDataAccess.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class UserController : BaseController
    {
        [Route("GetUsers")]
        [HttpGet]
        public List<SysUser> GetUsers() 
        {
            var query = UserService.GetSysUsers();
            return query.ToList();
        }

        [Route("GetStudents")]
        [HttpGet]
        public List<Student> GetStudents()
        {
            var query = UserService.GetStudents();
            return query.ToList();
        }
    }
}
