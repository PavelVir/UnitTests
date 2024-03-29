﻿
using A2v10.Data;
using A2v10.Data.Interfaces;
using A2v10.Infrastructure;
using A2v10.Request;
//using A2v10.Workflow;
using A2v10.Xaml;
using Microsoft.Extensions.Configuration;


namespace Server_side.Configuration
{
    public class TestConfig
	{
		private static IServiceLocator _currentService;

		public static void Start()
		{
			if (ServiceLocator.Start != null)
				return;

			ServiceLocator.Start = (IServiceLocator service) =>
			{
                var configuration = new ConfigurationBuilder()
					.AddJsonFile("//sql01/GITREP/USP_2022/UnitTests/App.config.json") 
					.Build();

                var profiler = new NullProfiler();
				var host = new TestApplicationHost(profiler, service, configuration)
				{
					HostingPath = Path.GetFullPath("/Web/A2v10.Web.Site")
				};

				var localizer = new NullLocalizer();
				var dbContext = new SqlDbContext(profiler, host, localizer);
				var messaging = new NullMessaging();
				//var workflowEngine = new WorkflowEngine(host, dbContext, messaging);
				var renderer = new XamlRenderer(profiler, host);
				var scripter = new VueDataScripter(host, localizer);

				service.RegisterService<IDbContext>(dbContext);
				//service.RegisterService<IWorkflowEngine>(workflowEngine);
				service.RegisterService<IApplicationHost>(host);
				service.RegisterService<IProfiler>(profiler);
				service.RegisterService<IRenderer>(renderer);
				service.RegisterService<ILocalizer>(localizer);
				service.RegisterService<IDataScripter>(scripter);
				service.RegisterService<IMessaging>(messaging);
				_currentService = service;
			};

			ServiceLocator.GetCurrentLocator = () =>
			{
				if (_currentService == null)
					new ServiceLocator();
				return _currentService;
			};
		}
	}
}
