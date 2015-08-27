using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using StackOverflow.Shared.Components.Logger;

namespace StackOverflow.Presentation.WebApp.Filters
{
	public class ExceptionFilterAttribute : FilterAttribute, IExceptionFilter
	{
		public void OnException(ExceptionContext filterContext)
		{
			FileLogger.Error(filterContext.Exception);

			filterContext.Result = new ViewResult()
			{
				ViewName = "Error",
				ViewData = new ViewDataDictionary<string>(filterContext.Exception.Message)
			
			};
			filterContext.ExceptionHandled = true;

		}
	}
}