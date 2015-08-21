using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using StackOverflow.Business.BusinessModels;
using StackOverflow.Business.Contracts;
using StackOverflow.Presentation.WebApp.Models.User;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Presentation.WebApp.Controllers
{
	public class AboutController : Controller
	{
		private IUserService userService;

		public AboutController(IUserService userService)
		{
			this.userService = userService;
		}

		//
		// GET: /About/User
		public ActionResult UserInfo(object id)
		{
			User user = userService.GetById(id);
			
			UserInfoViewModel userInfo = new UserInfoViewModel()
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				Nickname = String.IsNullOrWhiteSpace(user.Nickname) ? "No information" : user.Nickname,
				Post = String.IsNullOrWhiteSpace(user.Nickname) ? "No information" : user.Nickname,
				Experience = user.Experience ?? 0,
				Technologies = String.IsNullOrWhiteSpace(user.Technologies) ? "No information" : user.Technologies,
			};

			return View(userInfo);
		}

		//
		// GET: /About/Current
		[Authorize]
		public ActionResult CurrentUserInfo()
		{
			object id = User.Identity.GetUserId();

			User user = userService.GetById(id);

			UserInfoViewModel userInfo = new UserInfoViewModel()
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				Nickname = String.IsNullOrWhiteSpace(user.Nickname) ? "No information" : user.Nickname,
				Post = String.IsNullOrWhiteSpace(user.Nickname) ? "No information" : user.Nickname,
				Experience = user.Experience ?? 0,
				Technologies = String.IsNullOrWhiteSpace(user.Technologies) ? "No information" : user.Technologies,
			};

			UserRating rating = userService.GetRating(id);
			Mapper.CreateMap<UserRating, UserInfoViewModel>();
			Mapper.Map(rating, userInfo);

			return View(userInfo);
		}
	}
}