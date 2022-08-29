using ControllerServiceDataAccess.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ControllerServiceDataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IStudentService StudentService => GetService<IStudentService>();

        public IUserService UserService => GetService<IUserService>();

        protected T GetService<T>()
        {
            return HttpContext.RequestServices.GetService<T>();
        }
    }
}
