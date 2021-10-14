using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using WebApiApplicationCrud.AotofacMappingProfiles;
using WebApiApplicationCrud.ServiceRepositories;

namespace WebApiApplicationCrud.App_Start
{
	public class AutofacConfig
	{
		public static void Register()
		{
			var builder = new ContainerBuilder();
			var config = GlobalConfiguration.Configuration;
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
			RegisterServices(builder);
			builder.RegisterWebApiFilterProvider(config);
			builder.RegisterWebApiModelBinderProvider();
			var container = builder.Build();
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

		}

		public static void RegisterServices(ContainerBuilder builder)
		{
			//for auto mapping profile
			var config = new MapperConfiguration(cgf =>
			{
				cgf.AddProfile(new MappingProfiles());
			});
			builder.RegisterInstance(config.CreateMapper()).As<IMapper>().SingleInstance();

			//Dependency Injection Repositories
			builder.RegisterType<CountryRepository>().As<ICountryRepository>().InstancePerRequest();
			builder.RegisterType<StateRepository>().As<IStateRepository>().InstancePerRequest();
			builder.RegisterType<CityRepository>().As<ICityRepository>().InstancePerRequest();



		}
	}
}