using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;

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

			Mapper.CreateMap<Question, QuestionViewModel>()
				.ForMember("UserName", opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName));

			IList<QuestionViewModel> result = Mapper.Map<IEnumerable<Question>, List<QuestionViewModel>>(questions);

			return View(result);
		}
	}
}