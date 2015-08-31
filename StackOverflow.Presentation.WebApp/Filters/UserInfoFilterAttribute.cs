using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace StackOverflow.Presentation.WebApp.Filters
{
	public class UserInfoFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			Controller controller = (Controller) filterContext.Controller;
			
			if (controller.User.Identity.IsAuthenticated)
			{
				object userId = controller.User.Identity.GetUserId();
				object id = filterContext.ActionParameters.First().Value;

				if (userId.Equals(id))
				{
					filterContext.Result = new RedirectResult("/About/CurrentUserInfo");
				}
			}
		}
	}
}