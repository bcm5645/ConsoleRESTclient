using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsoleRESTclient
{
	class Repository
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("html_url")]
		public Uri GitHubHomeUrl { get; set; }

		[JsonPropertyName("homepage")]
		public Uri Homepage { get; set; }

		[JsonPropertyName("watchers")]
		public int Watchers { get; set; }

		[JsonPropertyName("description")]
		public string Description{ get; set; }

		[JsonPropertyName("pushed_at")]
		public DateTime LastPushUTC{ get; set; }

		public DateTime LastPush => LastPushUTC.ToLocalTime();
	}
}
