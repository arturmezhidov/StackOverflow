using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StackOverflow.Business.BusinessModels;
using StackOverflow.Business.Contracts;
using StackOverflow.Presentation.WebApp.Models.Account;
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
		public ActionResult Index()
		{
			string id = User.Identity.GetUserId();
			UserQuestionsViewModel userQuestions = new UserQuestionsViewModel(questionService.GetUserQuestions(id));
			return View(userQuestions);
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

				questionService.Add(question);

				return RedirectToAction("Index");
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
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /Questions/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		//
		// POST: /Questions/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
