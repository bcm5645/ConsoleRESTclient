using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace ConsoleRESTclient
{
	class Program
	{
		private static readonly HttpClient client = new HttpClient();

		static async Task Main(string[] args)
		{
			var repos = await ProcessRepositories();
			foreach (var repo in repos)
			{
				Console.WriteLine(repo.Name);
				Console.WriteLine(repo.Description);
				Console.WriteLine(repo.GitHubHomeUrl);
				Console.WriteLine(repo.Homepage);
				Console.WriteLine(repo.Watchers);
				Console.WriteLine(repo.LastPushUTC);
				Console.WriteLine(repo.LastPush);
				Console.WriteLine();
			}
		}

		private static async Task<List<Repository>> ProcessRepositories()
		{
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
			client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");


			//var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
			var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
			return await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
		}



	}


}
