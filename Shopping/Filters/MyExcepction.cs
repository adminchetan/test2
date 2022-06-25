using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Filters
{
    public class MyExcepction : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if(filterContext.Exception is NotImplementedException)
            {

            }

            if(filterContext.Exception is DllNotFoundException)
            {

                filterContext.Result = new ViewResult()
                {
                    ViewName = "ErrorPageNormal"
                };


            }
            else if(filterContext.Exception is DivideByZeroException)
            {

            }

            filterContext.Result = new ViewResult()
            {
                ViewName = "ErrorPageNormal"
            };

            filterContext.ExceptionHandled = true;

         
        }
    }
}
