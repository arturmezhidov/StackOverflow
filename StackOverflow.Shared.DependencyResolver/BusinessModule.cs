﻿using Ninject.Modules;
using StackOverflow.Business.BusinessComponents.Services;
using StackOverflow.Business.Contracts;

namespace StackOverflow.Shared.DependencyResolver
{
	public class BusinessModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IIdentityUserService>().To<IdentityUserService>();
			Bind<IQuestionService>().To<QuestionService>();
			Bind<IUserService>().To<UserService>();
			Bind<IAnswerService>().To<AnswerService>();
		}
	}
}
