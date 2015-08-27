using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using WebGrease.Css.Extensions;

using StackOverflow.Business.Contracts;
using StackOverflow.Presentation.WebApp.Filters;
using StackOverflow.Presentation.WebApp.Models;
using StackOverflow.Presentation.WebApp.Models.Answer;
using StackOverflow.Shared.Entities;


namespace StackOverflow.Presentation.WebApp.Controllers
{
	[ExceptionFilter]
	public class AnswerController : ApiController
	{
		private readonly IAnswerService service;

		public AnswerController(IAnswerService service)
		{
			this.service = service;
		}

		// GET api/answer/5
		public IEnumerable<AnswerViewModel> GetOfQuestion(int id)
		{
			List<Answer> answers = new List<Answer>(service.GetOfQuestion(id));

			Mapper.CreateMap<Answer, AnswerViewModel>()
				.ForMember("UserName", opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
				.ForMember("Date", opt => opt.MapFrom(c => String.Format("{1}, {0}", c.Date.ToShortDateString(), c.Date.ToShortTimeString())));

			IList<AnswerViewModel> result = Mapper.Map<List<Answer>, List<AnswerViewModel>>(answers);

			if (User.Identity.IsAuthenticated)
			{
				string userId = User.Identity.GetUserId();
				result.ForEach(model => model.Liked = service.IsLike(userId, model.Id));
			}

			return result;
		}

		// POST api/answer
		[Authorize]
		public AnswerViewModel Post([FromBody]AnswerPostModel value)
		{
			if (value == null || String.IsNullOrWhiteSpace(value.Description))
			{
				return null;
			}

			Answer answer = service.Create(User.Identity.GetUserId(), value.QuestionId, value.Description);

			Mapper.CreateMap<Answer, AnswerViewModel>()
				.ForMember("UserName", opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
				.ForMember("LikesCount", opt => opt.MapFrom(c => c.Likes.Count))
				.ForMember("Date", opt => opt.MapFrom(c => String.Format("{1}, {0}", c.Date.ToShortDateString(), c.Date.ToShortTimeString())));

			AnswerViewModel result = Mapper.Map<Answer, AnswerViewModel>(answer);

			return result;
		}

		// PUT api/answer/5
		[HttpPut]
		public bool Accept(int id, [FromBody]string value)
		{
			return service.Accept(User.Identity.GetUserId(), id);
		}

		// DELETE api/answer/5
		public void Delete(int id)
		{
		}
	}
}
