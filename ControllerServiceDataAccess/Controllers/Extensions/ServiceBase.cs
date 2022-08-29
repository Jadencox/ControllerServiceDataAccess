using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ControllerServiceDataAccess.Extensions
{
    public class ServiceBase
    {
        protected IServiceProvider _serviceProvider;

        protected IServiceProvider ServiceProvider { get; }

        public ServiceBase(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            var context = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
            _serviceProvider = context == null ? serviceProvider : context.RequestServices;
        }

        protected T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }

    public class ServiceBase<TDataAccess> : ServiceBase where TDataAccess : RepositoryBase
    {
        /// <summary>
        /// 数据访问层
        /// </summary>
        public TDataAccess DataAccess { get; }

        public ServiceBase(TDataAccess dataAccess, IServiceProvider serviceProvider) : base(serviceProvider) 
        {
            DataAccess = dataAccess;
        }
    }
}
