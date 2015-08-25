using System.Collections.Generic;
using System.Web.Mvc;

using StackOverflow.Business.Contracts;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Presentation.WebApp.Controllers
{
	public class HomeController : Controller
	{
		private IQuestionService service;

		public HomeController(IQuestionService service) 
		{
			this.service = service;
		}

		public ActionResult Index()
		{
			IEnumerable<Question> questions = service.GetAll();
			return View(questions);
		}
	}
}