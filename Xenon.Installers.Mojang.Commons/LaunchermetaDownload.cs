using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Xenon.Installers.Mojang.Commons.Launchermeta;

namespace Xenon.Installers.Mojang.Commons
{
	internal class LaunchermetaDownload
	{
#pragma warning disable CA1822
		public async Task<LauncherMain> Download()
#pragma warning restore CA1822
		{
			HttpClient client = new();
			String result;

			using HttpResponseMessage response = await client.GetAsync("https://launchermeta.mojang.com/mc/game/version_manifest.json");
			result = await response.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<LauncherMain>(result) ?? 
				throw new MojangException("Invalid data downloaded from launchermeta.mojang.com", 0);
		}
	}
}
