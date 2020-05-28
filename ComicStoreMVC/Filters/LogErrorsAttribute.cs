using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreMVC.Filters
{
    public class LogErrorsAttribute : FilterAttribute, IExceptionFilter
    {

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public void OnException(ExceptionContext filterContext)
        {

            if (filterContext.Exception != null)
            {
                _logger.Error(filterContext.Exception, "Exception");
            }
        }
    }
}