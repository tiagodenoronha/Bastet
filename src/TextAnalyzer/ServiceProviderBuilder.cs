using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using TextAnalyzer;
using TextAnalyzer.Interfaces;
using TextAnalyzer.Services;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(Startup))]
namespace TextAnalyzer
{
	internal class ServiceProviderBuilder : IServiceProviderBuilder
	{
		private readonly ILoggerFactory _loggerFactory;

		public ServiceProviderBuilder(ILoggerFactory loggerFactory)
		{
			_loggerFactory = loggerFactory;
		}

		public IServiceProvider Build()
		{
			var services = new ServiceCollection();

			services.AddScoped<ILUISService, LUISService>();
			services.AddScoped<IQnAService, QnAService>();
			services.AddScoped<ITextAnalyticsService, TextAnalyticsService>();
			services.AddScoped<IQueueService, QueueService>();

			// Important: We need to call CreateFunctionUserCategory, otherwise our log entries might be filtered out.
			services.AddSingleton(_ => _loggerFactory.CreateLogger(LogCategories.CreateFunctionUserCategory("TextAnalyzerFunction")));

			return services.BuildServiceProvider();
		}
	}
}
