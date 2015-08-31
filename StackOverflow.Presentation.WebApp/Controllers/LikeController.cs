using System.Web.Http;
using Microsoft.AspNet.Identity;

using StackOverflow.Business.Contracts;
using StackOverflow.Presentation.WebApp.Filters;
using StackOverflow.Presentation.WebApp.Models.Like;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Presentation.WebApp.Controllers
{
	[Authorize]
	[ExceptionFilter]
	public class LikeController : ApiController
	{
		protected string UserId
		{
			get
			{
				return User.Identity.GetUserId(); 
			}
		}

		private readonly IAnswerService service;

		public LikeController(IAnswerService service)
		{
			this.service = service;
		}

		// POST api/like
		public LikeInfoViewModel Post([FromBody]LikeViewModel model)
		{
			UserLike like = service.Liking(UserId, model.AnswerId);

			LikeInfoViewModel likeViewModel = new LikeInfoViewModel(like, true);

			return likeViewModel;
		}
	}
}
