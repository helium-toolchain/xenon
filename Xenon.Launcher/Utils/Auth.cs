using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;

using Xenon.Launcher.Properties.Account;
using System.Threading.Tasks;

namespace Xenon.Launcher.Properties.Utils
{
	public class Auth
	{
		private static HttpClient httpClient = new HttpClient();
		public void CheckGameOwnership(String accessToken)
		{
			throw new NotImplementedException();
		}

		public void GetProfile(String accessToken)
		{
			throw new NotImplementedException();
		}
		//
		// Yggdrasil auth scheme for Mojang accounts
		//
		public MojangAccount MojangAuth(String Username, String Password)
		{
			httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("application/json");

			Guid clientToken = Guid.NewGuid();

			JObject req = new();
			JObject agent = new();

			agent.Add("name", "Minecraft");
			agent.Add("version", 1);

			req.Add("agent", agent);
			req.Add("username", Username);
			req.Add("password", Password);
			req.Add("clientToken", clientToken);

			var response = MojangAuthRequest(req);
			JObject resp = new();
			resp.Add(response);

			String accessToken = resp.GetValue("accessToken").ToString();

			Guid respClientToken = Guid.Parse(resp.GetValue("clientToken").ToString());

			if(!respClientToken.Equals(clientToken))
				throw new Exception("Response token " + respClientToken + " is not equal to sent token " + clientToken);

			JToken selectedProfile = resp.SelectToken("selectedProfiles");

			Guid uuid = Guid.Parse(selectedProfile.SelectToken("id").ToString());

			String username = selectedProfile.SelectToken("name").ToString();

			return new MojangAccount(username, accessToken, clientToken, uuid);
		}

		private async Task<String> MojangAuthRequest(JObject req)
		{
			HttpResponseMessage response = await httpClient.PostAsync("https://authserver.mojang.com/authenticate",
				new StringContent(req.ToString(), Encoding.UTF8, "application/json"));
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsStringAsync();
		}
	}
}

