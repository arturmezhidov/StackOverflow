using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using StackOverflow.Business.Contracts;
using StackOverflow.Presentation.WebApp.Models.Answer;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Presentation.WebApp.Controllers
{
	[Authorize]
	public class LikeController : ApiController
	{
		private readonly IAnswerService service;

		public LikeController(IAnswerService service)
		{
			this.service = service;
		}

		// POST api/like
		public LikeViewModel Post([FromBody]LikeViewModel model)
		{
			string userId = User.Identity.GetUserId();
			int answerId = model.AnswerId;

			UserLike like = service.Liking(userId, answerId);

			model.LikesCount = like.LikesCount;
			model.Liked = like.Liked;
			model.Success = true;

			return model;
		}
	}
}
