using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;

using StackOverflow.Business.Contracts;
using StackOverflow.Presentation.WebApp.Filters;
using StackOverflow.Presentation.WebApp.Models.Question;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Presentation.WebApp.Controllers
{
	[Authorize]
	[ExceptionFilter]
	public class QuestionsController : Controller
	{
		private readonly IQuestionService questionService;

		public QuestionsController(IQuestionService questionService)
		{
			this.questionService = questionService;
		}

		//
		// GET: /Questions/
		[AllowAnonymous]
		public ActionResult Index()
		{
			IEnumerable<Question> questions = questionService.GetActiveQuestions();

			Mapper.CreateMap<Question, QuestionViewModel>()
				.ForMember("UserName", opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName));

			IList<QuestionViewModel> questionViewModels = Mapper.Map<IEnumerable<Question>, List<QuestionViewModel>>(questions);

			return View(questionViewModels);
		}

		//
		// GET: /Questions/Create
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Questions/Create
		[HttpPost]
		public ActionResult Create(QuestionViewModel model)
		{
			try
			{
				Mapper.CreateMap<QuestionViewModel, Question>();
				Question question = Mapper.Map<QuestionViewModel, Question>(model);

				question.UserId = User.Identity.GetUserId();

				question = questionService.Add(question);

				return RedirectToRoute(new
				{
					controller = "Questions",
					action = "Answers",
					id = question.Id
				});
			}
			catch
			{
				return View();
			}
		}

		//s
		// GET: /Questions/Edit/5
		public ActionResult Edit(int id)
		{
			Question question = questionService.GetById(id);
			Mapper.CreateMap<Question, QuestionViewModel>();
			QuestionViewModel vm = Mapper.Map<Question, QuestionViewModel>(question);
			return View(vm);
		}

		//
		// POST: /Questions/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, QuestionViewModel model)
		{
			try
			{
				Question question = questionService.GetById(id);
				question.Title = model.Title;
				question.Content = model.Content;
				questionService.Update(question);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /Questions/Delete/5
		[AllowAnonymous]
		public ActionResult Answers(int id)
		{
			Question question = questionService.GetById(id);
			Mapper.CreateMap<Question, QuestionViewModel>();
			QuestionViewModel vm = Mapper.Map<Question, QuestionViewModel>(question);
			vm.UserName = String.Format("{0} {1}", question.User.FirstName, question.User.LastName);

			if (User.Identity.IsAuthenticated)
			{
				vm.IsOwner = questionService.IsOwner(User.Identity.GetUserId(), question.Id);
			}

			return View(vm);
		}
	}
}
