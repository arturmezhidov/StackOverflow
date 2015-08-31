using System.Collections.Generic;
using System.Web.Mvc;

using StackOverflow.Business.Contracts;
using StackOverflow.Presentation.WebApp.Filters;
using StackOverflow.Presentation.WebApp.Models.Question;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Presentation.WebApp.Controllers
{
	[ExceptionFilter]
	public class HomeController : Controller
	{
		private readonly IQuestionService service;

		public HomeController(IQuestionService service) 
		{
			this.service = service;
		}

		public ActionResult Index()
		{
			IEnumerable<Question> questions = service.GetAll();

			QuestionInfoCollectionViewModel questionsViewModel = new QuestionInfoCollectionViewModel(questions);

			return View(questionsViewModel);
		}
	}
}