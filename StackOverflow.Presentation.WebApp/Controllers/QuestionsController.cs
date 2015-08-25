using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;

using StackOverflow.Business.Contracts;
using StackOverflow.Presentation.WebApp.Models.Question;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Presentation.WebApp.Controllers
{
	[Authorize]
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
			return View(questions);
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
		public ActionResult Create(QestionViewModel model)
		{
			try
			{
				Mapper.CreateMap<QestionViewModel, Question>();
				Question question = Mapper.Map<QestionViewModel, Question>(model);

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
			Question question = questionService.GetQuestionById(id);
			Mapper.CreateMap<Question, QestionViewModel>();
			QestionViewModel vm = Mapper.Map<Question, QestionViewModel>(question);
			return View(vm);
		}

		//
		// POST: /Questions/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, QestionViewModel model)
		{
			try
			{
				Question question = questionService.GetQuestionById(id);
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
			Question question = questionService.GetQuestionById(id);
			Mapper.CreateMap<Question, QestionViewModel>();
			QestionViewModel vm = Mapper.Map<Question, QestionViewModel>(question);
			vm.UserName = String.Format("{0} {1}", question.User.FirstName, question.User.LastName);

			return View(vm);
		}
	}
}
