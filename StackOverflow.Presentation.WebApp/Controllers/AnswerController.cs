using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using WebGrease.Css.Extensions;

using StackOverflow.Business.Contracts;
using StackOverflow.Presentation.WebApp.Filters;
using StackOverflow.Presentation.WebApp.Models.Answer;
using StackOverflow.Shared.Entities;


namespace StackOverflow.Presentation.WebApp.Controllers
{
	[ExceptionFilter]
	public class AnswerController : ApiController
	{
		protected string UserId
		{
			get
			{
				return User.Identity.GetUserId(); 
			}
		}

		private readonly IAnswerService service;

		public AnswerController(IAnswerService service)
		{
			this.service = service;
		}

		// GET api/answer/5
		[HttpGet]
		public AnswerInfoCollectionViewModel GetOfQuestion(int id)
		{
			IEnumerable<Answer> answers = service.GetOfQuestion(id);

			AnswerInfoCollectionViewModel answersViewModel = new AnswerInfoCollectionViewModel(answers);

			if (User.Identity.IsAuthenticated)
			{
				answersViewModel.ForEach(model => model.Liked = service.IsLike(UserId, model.Id));
			}

			return answersViewModel;
		}

		// POST api/answer
		[Authorize]
		public AnswerInfoViewModel Powst([FromBody]AnswerViewModel model)
		{
			if (model == null || String.IsNullOrWhiteSpace(model.Description))
			{
				return null;
			}

			Answer answer = service.Create(UserId, model.QuestionId, model.Description);

			AnswerInfoViewModel answerViewModel = new AnswerInfoViewModel(answer);

			return answerViewModel;
		}

		// PUT api/answer/5
		[HttpPut]
		public bool Accept(int id, [FromBody]string value)
		{
			bool result = service.Accept(UserId, id);

			return result;
		}
	}
}
