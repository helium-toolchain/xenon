using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.Launcher.Properties.Account
{
	public class MojangAccount : IAccount
	{
		private HttpClient httpClient = new HttpClient();

		private String username;
		private String accessToken;
		private Guid clientToken;
		private Guid uuid;
		private Int32 uses;
		private DateTime lastUse;

		public MojangAccount(String username, String accessToken, Guid clientToken, Guid uuid)
		{
			this.username = username;
			this.accessToken = accessToken;
			this.clientToken = clientToken;
			this.uuid = uuid;
		}

		public String Alias() => username;

		public void Login()
		{
			throw new NotImplementedException();
		}
		public Boolean Validate()
		{
			httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("application/json");

			JObject validate = new();
			validate.Add("accessToken", accessToken);
			validate.Add("clientToken", clientToken);

			return ValidateRequest(validate).Result;
		}
		private async Task<Boolean> ValidateRequest(JObject req)
		{
			HttpResponseMessage response = await httpClient.PostAsync("https://authserver.mojang.com/validate",
				new StringContent(req.ToString(), Encoding.UTF8, "application/json"));
			response.EnsureSuccessStatusCode();

			if(response.StatusCode == HttpStatusCode.NoContent)
			{
				return true;
			}
			else if(response.StatusCode == HttpStatusCode.Forbidden)
			{
				//Console.WriteLine(response.Content);
				return false;
			}
			Console.WriteLine(response.StatusCode);
			return false;
		}

		public void Refresh()
		{
			throw new NotImplementedException();
		}

		private async Task<HttpStatusCode> RefreshRequest(JObject req)
		{
			HttpResponseMessage response = await httpClient.PostAsync("https://authserver.mojang.com/validate",
				new StringContent(req.ToString(), Encoding.UTF8, "application/json"));
			response.EnsureSuccessStatusCode();
			return response.StatusCode;
		}

		public Int32 Uses() => uses;

		public DateTime LastUse() => lastUse;

		public void Use()
		{
			uses++;
			lastUse = DateTime.Now;
		}

		public Guid Uuid() => uuid;
	}
}
