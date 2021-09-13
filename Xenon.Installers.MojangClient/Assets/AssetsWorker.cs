using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.Installers.MojangClient.Assets
{
	public class AssetsWorker
	{
		public const String AssetsUrl = "http://resources.download.minecraft.net";
		public const String AssetsFolder = ".minecraft/assets/objects";
		public static readonly HttpClient httpClient;

		static AssetsWorker()
		{
			httpClient = new();
		}

#pragma warning disable CA1822
		public async Task DownloadAsset(String hash, String installFolder)
#pragma warning restore CA1822
		{
			if(!Directory.Exists($"{installFolder}/{AssetsFolder}/{hash:2}"))
			{
				Directory.CreateDirectory($"{installFolder}/{AssetsFolder}/{hash:2}");
			}

			HttpResponseMessage message = await httpClient.GetAsync($"{AssetsUrl}/{hash:2}/{hash}");

			await using Stream memoryStream = await message.Content.ReadAsStreamAsync();
			await using Stream fileStream = File.Create($"{installFolder}/{AssetsFolder}/{hash:2}/{hash}");

			memoryStream.Seek(0, SeekOrigin.Begin);
			memoryStream.CopyTo(fileStream);

			fileStream.Flush();
		}
	}
}
