using ControllerServiceDataAccess.IServices;
using ControllerServiceDataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerServiceDataAccess.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class StudentController : BaseController
    {
        [Route("InsertStu")]
        [HttpPost]
        public bool InsertStu(string str)
        {
            return StudentService.InsertStu(str);
        }

        [Route("GetStudents")]
        [HttpGet]
        public List<Student> GetStudents()
        {
            var Users = StudentService.GetStudents();
            return Users;
        }
    }
}
