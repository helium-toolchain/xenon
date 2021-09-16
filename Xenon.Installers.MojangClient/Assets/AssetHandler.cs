using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Xenon.Installers.MojangClient.Assets
{
	public class AssetHandler
	{
		[SuppressMessage("Design", "CA1822")]
		public async Task DownloadAssets(String mojangUrl, String installDirectory, String assetsId)
		{
			HttpClient client = new();
			HttpResponseMessage response = await client.GetAsync(mojangUrl);

			Directory.CreateDirectory($"{installDirectory}/.minecraft/assets/indexes");
			Directory.CreateDirectory($"{installDirectory}/.minecraft/assets/objects");

			await using Stream memoryStream = await response.Content.ReadAsStreamAsync();
			await using FileStream fileStream = File.Create($"{installDirectory}/.minecraft/assets/indexes/{assetsId}.json");

			memoryStream.CopyTo(fileStream);
			fileStream.Flush();

			fileStream.Close();

			// read and deserialize assets

			AssetIndex index = await JsonSerializer.DeserializeAsync<AssetIndex>(memoryStream);

			foreach(AssetIndex.AssetIndexObject v in index.Objects.Values)
			{
				_ = Task.Run(async () => { await new AssetsWorker().DownloadAsset(v.Hash, installDirectory); });
			}
		}
	}
}
