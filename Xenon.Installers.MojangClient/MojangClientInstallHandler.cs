using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Xenon.InstallerLoader;
using Xenon.Installers.Mojang.Commons.VersionJson;
using Xenon.Installers.MojangClient.Assets;
using Xenon.Installers.MojangClient.Libraries;

namespace Xenon.Installers.MojangClient
{
	public class MojangClientInstallHandler : IInstallHandler
	{
		public async void Install(String version, String installDirectory)
		{
			VersionMain v = MojangData.MojangHelper[version];
			Directory.CreateDirectory($"{installDirectory}/.minecraft");

			// configureawait is used here to fully detach the assets and library downloads from anything else that may be happening.
			// just pray there's no major issues with their code
			_ = Task.Run(async () => 
			{ 
				await new AssetHandler()
					.DownloadAssets(v.AssetsIndex.Url, installDirectory, v.Assets)
						.ConfigureAwait(false); 
			}).ConfigureAwait(false);

			_ = Task.Run(() => 
			{ 
				new LibraryHandler()
					.DownloadLibraries(v, installDirectory); 
			}).ConfigureAwait(false);

			// download client.jar
			HttpClient client = new();

			HttpResponseMessage response = await client.GetAsync(v.Downloads.Client.Url);
			response.EnsureSuccessStatusCode();

			await using Stream memoryStream = await response.Content.ReadAsStreamAsync();
			await using FileStream fileStream = File.Create($"{installDirectory}/client.jar");

			memoryStream.Seek(0, SeekOrigin.Begin);
			memoryStream.CopyTo(fileStream);

			String Sha1 = Encoding.UTF8.GetString(SHA1.Create().ComputeHash(fileStream));

			if(Sha1 == v.Downloads.Client.Sha1)
			{
				fileStream.Flush();
			}
			else
			{
				throw new InvalidDataException("client.jar download either failed or the download was intercepted/happened from a malicious server");
			}

			FileInfo fileInfo = new($"{installDirectory}/client.jar");

			if(!(fileInfo.Length == v.Downloads.Client.Size))
			{
				throw new InvalidDataException("client.jar download either failed or the download was intercepted/happened from a malicious server");
			}

			// create some additional folders
			Directory.CreateDirectory($"{installDirectory}/.minecraft/resourcepacks");
			Directory.CreateDirectory($"{installDirectory}/.minecraft/saves");
		}

		public void PatchVersionMeta(String version, String installDirectory)
		{
			VersionMain v = MojangData.MojangHelper[version];

			StreamReader reader = new($"{installDirectory}/.xenon.json");
			XenonMeta meta = JsonSerializer.Deserialize<XenonMeta>(reader.ReadToEnd());
			reader.Close();

			List<String> arguments = new();

			foreach(Argument y in v.Arguments.GameArguments)
			{
				if(y.Rules != null 
					&& y.Rules[0].Action == "allow" 
					&& y.Rules[0].OperatingSystem.Name == "osx")
				{
					continue;
				}

				arguments = (List<String>)arguments.Concat(y.Values);
			}

			meta.Arguments = arguments.ToArray();

			meta.DefaultJavaVersion = v.JavaVersion.Version.ToString();

			StreamWriter writer = new($"{installDirectory}/.xenon.json");
			writer.Write(JsonSerializer.Serialize(meta, new JsonSerializerOptions()
			{
				WriteIndented = true
			}));
			writer.Close();
		}
	}
}
