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
using StackOverflow.Presentation.WebApp.Models.User;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Presentation.WebApp.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}