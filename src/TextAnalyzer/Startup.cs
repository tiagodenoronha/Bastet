using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using System.Collections.Generic;
using System.Text;
using TextAnalyzer;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(Startup))]
namespace TextAnalyzer
{
	internal class Startup : IWebJobsStartup
	{
		public void Configure(IWebJobsBuilder builder) =>
			builder.AddDependencyInjection<ServiceProviderBuilder>();
	}
}
