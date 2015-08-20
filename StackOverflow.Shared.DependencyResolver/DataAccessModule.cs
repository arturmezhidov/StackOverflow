using Ninject.Modules;
using StackOverflow.Data.Contracts;
using StackOverflow.Data.DataAccess.UnitsOfWork;

namespace StackOverflow.Shared.DependencyResolver
{
	public class DataAccessModule : NinjectModule
	{
		private readonly string connectionString;

		public DataAccessModule(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public override void Load()
		{
			Bind<IUnitOfWork>()
				.To<EFUnitOfWork>()
				.WithConstructorArgument(connectionString);
		}
	}
}
