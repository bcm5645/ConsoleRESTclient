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
			ProcessWhitelist();
			Console.WriteLine("Oczekiwanie na przetworzenie żądania przez MF");
			//foreach(var wl in whitelist)
			//{

			//}


			//var repos = await ProcessRepositories();
			//foreach (var repo in repos)
			//{
			//	Console.WriteLine(repo.Name);
			//	Console.WriteLine(repo.Description);
			//	Console.WriteLine(repo.GitHubHomeUrl);
			//	Console.WriteLine(repo.Homepage);
			//	Console.WriteLine(repo.Watchers);
			//	Console.WriteLine(repo.LastPushUTC);
			//	Console.WriteLine(repo.LastPush);
			//	Console.WriteLine();
			//}
			Console.ReadKey();
		}

		private static async Task<List<Repository>> ProcessRepositories()
		{
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
			client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

			var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");

			return await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
		}

		private static async void ProcessWhitelist()
		{
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

			Console.WriteLine("Podaj NIP do zweryfikowania");
			var nip = Console.ReadLine().Replace("-","");

			var stringTask = client.GetStreamAsync($"https://wl-api.mf.gov.pl/api/search/nip/{nip}?date=2020-05-25");
			var wl = await JsonSerializer.DeserializeAsync<VatWhiletList>(await stringTask);
			if (wl != null)
			{
				Console.WriteLine(wl.Result.resultSubject.Name);
				Console.WriteLine(wl.Result.resultSubject.WorkingAddress);
				Console.WriteLine(wl.Result.resultSubject.NIP);
				Console.WriteLine(wl.Result.resultSubject.REGON);
				Console.WriteLine(wl.Result.resultSubject.VATstatus);
			}
		}
	}
}