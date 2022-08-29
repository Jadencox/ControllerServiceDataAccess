using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;

namespace ControllerServiceDataAccess.Extensions
{
    public abstract class RepositoryBase
    {
        public string UserName { get; set; }

        public string UserId { get; set; }

        public IServiceProvider Provider { get; set; }
    }

    public abstract class RepositoryBase<TDbContext> : RepositoryBase, IDisposable where TDbContext : DbContext
    {
        private bool _isDisposed = false;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Gets the <see cref="DbContext"/>
        /// </summary>
        public TDbContext DbContext { get; private set; }

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase&lt;TDbContext&gt;"/> class.
        /// </summary>
        /// <param name="dbContext">The <see cref="DbContext"/></param>
        /// <param name="httpContextAccessor"></param>
        public RepositoryBase(TDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            //Guard.ArgumentNotNull(dbContext, "dbContext");
            _httpContextAccessor = httpContextAccessor;
            if (httpContextAccessor != null)
            {
                UserName = httpContextAccessor.HttpContext?.User.Identity.Name ?? "";
                //UserId = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.UserId)?.Value ?? "";
            }

            this.DbContext = dbContext;

        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">True/false</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    this.DbContext.Dispose();
                }

                _isDisposed = true;
            }
        }

        #endregion
    }

}
