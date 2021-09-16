using System;
using System.IO;
using System.Net;

namespace Xenon.Launcher
{
	public class Authenticate
	{
		public String AccessToken { get; private set; }
		public void ObtainAccessToken(String username, String password)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://authserver.mojang.com/authenticate");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";

			using StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
			String json = "{\"agent\":{\"name\":\"Minecraft\",\"version\":1},\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"clientToken\":\"6c9d237d-8fbf-44ef-b46b-0b8a854bf391\"}";

			streamWriter.Write(json);
			streamWriter.Flush();
			streamWriter.Close();

			HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			using StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream());
			String result = streamReader.ReadToEnd();

			AccessToken = result;
		}
	}
}