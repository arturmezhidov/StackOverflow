using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

using StackOverflow.Business.Contracts;
using StackOverflow.Presentation.WebApp.Filters;
using StackOverflow.Presentation.WebApp.Models.Question;
using StackOverflow.Presentation.WebApp.Models.User;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Presentation.WebApp.Controllers
{
	[ExceptionFilter]
	public class AboutController : Controller
	{
		private readonly IUserService userService;

		public AboutController(IUserService userService)
		{
			this.userService = userService;
		}

		//
		// GET: /About/User
		[UserInfoFilter]
		public ActionResult UserInfo(string id)
		{
			User user = userService.GetById(id);

			UserViewModel userViewModel = new UserViewModel(user);

			return View(userViewModel);
		}
		
		//
		// GET: /About/Current
		[Authorize]
		public ActionResult CurrentUserInfo()
		{
			string id = User.Identity.GetUserId();

			User user = userService.GetById(id);
			UserViewModel userViewModel = new UserViewModel(user);

			Rating rating = userService.GetRating(id);
			RatingViewModel ratingViewModel =new RatingViewModel(rating);

 
			IEnumerable<Question> questions = user.Questions;
			QuestionInfoCollectionViewModel questionsViewModel = new QuestionInfoCollectionViewModel(questions);

			UserInfoViewModel viewModel = new UserInfoViewModel() 
			{
				User = userViewModel,
				Rating = ratingViewModel,
				Questions = questionsViewModel
			};

			return View(viewModel);
		}
	}
}