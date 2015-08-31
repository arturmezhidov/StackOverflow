using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

using StackOverflow.Business.Contracts;
using StackOverflow.Presentation.WebApp.Filters;
using StackOverflow.Presentation.WebApp.Models.Question;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Presentation.WebApp.Controllers
{
	[Authorize]
	[ExceptionFilter]
	public class QuestionController : Controller
	{
		private readonly IQuestionService questionService;

		public QuestionController(IQuestionService questionService)
		{
			this.questionService = questionService;
		}

		//
		// GET: /Questions/
		[AllowAnonymous]
		public ActionResult Index()
		{
			IEnumerable<Question> questions = questionService.GetActiveQuestions();

			QuestionInfoCollectionViewModel questionsViewModel = new QuestionInfoCollectionViewModel(questions);

			return View(questionsViewModel);
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
				Question question = model.ToQuestion();

				question = questionService.Add(question, User.Identity.GetUserId());

				return RedirectToRoute(new
				{
					controller = "Question",
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

			QuestionViewModel questionViewModel = new QuestionViewModel(question);

			return View(questionViewModel);
		}

		//
		// POST: /Questions/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, QuestionViewModel model)
		{
			try
			{
				Question question = questionService.GetById(id);

				question = model.UpdateQuestion(question);

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

			QuestionWithAnswersViewModel questionWithAnswersViewModel = new QuestionWithAnswersViewModel(question);

			if (User.Identity.IsAuthenticated)
			{
				questionWithAnswersViewModel.IsOwner = questionService.IsOwner(User.Identity.GetUserId(), question.Id);
			}

			return View(questionWithAnswersViewModel);
		}
	}
}
