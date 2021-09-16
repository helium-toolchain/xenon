using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

using Xenon.InstallerLoader;
using Xenon.Installers.Mojang.Commons.VersionJson;

namespace Xenon.Installers.MojangServer
{
	public class MojangServerInstallHandler : IInstallHandler
	{
		public async void Install(String version, String installDirectory)
		{
			VersionMain v = MojangData.MojangHelper[version];

			HttpClient client = new();

			HttpResponseMessage response = await client.GetAsync(v.Downloads.Server.Url);
			response.EnsureSuccessStatusCode();

			await using Stream memoryStream = await response.Content.ReadAsStreamAsync();
			await using FileStream fileStream = File.Create($"{installDirectory}/server.jar");

			memoryStream.Seek(0, SeekOrigin.Begin);
			memoryStream.CopyTo(fileStream);

			String Sha1 = Encoding.UTF8.GetString(SHA1.Create().ComputeHash(fileStream));

			if(Sha1 == v.Downloads.Server.Sha1)
			{
				fileStream.Flush();
			}
			else
			{
				throw new InvalidDataException("server.jar download either failed or the download was intercepted/happened from a malicious server");
			}

			FileInfo fileInfo = new($"{installDirectory}/server.jar");

			if(fileInfo.Length == v.Downloads.Server.Size)
			{
				return;
			}
			else
			{
				throw new InvalidDataException("server.jar download either failed or the download was intercepted/happened from a malicious server");
			}
		}

		[Obsolete("Server installer, no version meta file needed")]
		public void PatchVersionMeta(String version, String installDirectory) => throw new NotImplementedException();
	}
}
