﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
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
		public ActionResult UserInfo(string id)
		{
			if (User.Identity.IsAuthenticated) 
			{
				object userId = User.Identity.GetUserId();
				if (userId.Equals(id)) 
				{
					return RedirectToAction("CurrentUserInfo");
				}
			}

			User user = userService.GetById(id);
			UserViewModel userInfo = getUserInfoViewModel(user);
			return View(userInfo);
		}
		
		//
		// GET: /About/Current
		[Authorize]
		public ActionResult CurrentUserInfo()
		{
			string id = User.Identity.GetUserId();

			User user = userService.GetById(id);
			UserViewModel userInfo = getUserInfoViewModel(user);
			

			Mapper.CreateMap<Rating, RatingViewModel>();
			Rating rating = userService.GetRating(id);
			RatingViewModel ratingViewModel = Mapper.Map<Rating, RatingViewModel>(rating);

			IEnumerable<Question> questions = user.Questions;
			Mapper.CreateMap<Question, QuestionViewModel>()
				.ForMember("UserName", opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName));
			IList<QuestionViewModel> questionViewModels = Mapper.Map<IEnumerable<Question>, List<QuestionViewModel>>(questions);

			UserInfoViewModel viewModel = new UserInfoViewModel() 
			{
				User = userInfo,
				Rating = ratingViewModel,
				Questions = questionViewModels
			};

			return View(viewModel);
		}

		private UserViewModel getUserInfoViewModel(User user) 
		{
			UserViewModel userInfo = new UserViewModel() {
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				Nickname = String.IsNullOrWhiteSpace(user.Nickname) ? "No information" : user.Nickname,
				Post = String.IsNullOrWhiteSpace(user.Post) ? "No information" : user.Post,
				Experience = user.Experience ?? 0,
				Technologies = String.IsNullOrWhiteSpace(user.Technologies) ? "No information" : user.Technologies,
			};

			return userInfo;
		}
	}
}