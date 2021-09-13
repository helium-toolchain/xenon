using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Xenon.Installers.MojangClient.Assets
{
	public class AssetHandler
	{
		[SuppressMessage("Design", "CA1822")]
		public async Task DownloadAssets(String mojangUrl, String installDirectory)
		{
			HttpClient client = new();
			HttpResponseMessage response = await client.GetAsync(mojangUrl);

			await using Stream memoryStream = await response.Content.ReadAsStreamAsync();
			await using FileStream fileStream = File.Create($"{installDirectory}/.minecraft/assets/indexes");

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
