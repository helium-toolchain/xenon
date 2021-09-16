using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

using Xenon.Installers.Mojang.Commons.Launchermeta;
using Xenon.Installers.Mojang.Commons.VersionJson;

namespace Xenon.Installers.Mojang.Commons
{
	public class MojangHelper
	{
		private static LauncherMain __launchermetaMain;
		private static JsonSerializerOptions __versionSerializerOptions;

		public MojangHelper()
		{
			__versionSerializerOptions = new()
			{
				Converters =
				{
					new ArgumentConditionJsonConverter()
				}
			};
		}

#pragma warning disable CA1822
		public LauncherMain LaunchermetaMain
#pragma warning restore CA1822
		{
			get
			{
				if(__launchermetaMain == null)
					__launchermetaMain = new LaunchermetaDownload().Download().Result;
				return __launchermetaMain;
			}
			internal set => __launchermetaMain = value;
		}

		public VersionMain this[String version]
		{
			get
			{
				String versionUrl = LaunchermetaMain.Versions.First(xm => xm.VersionId == version).Url;

				HttpClient client = new();

				using HttpResponseMessage response = client.GetAsync(versionUrl).Result;
				String result = response.Content.ReadAsStringAsync().Result;

				return JsonSerializer.Deserialize<VersionMain>(result, __versionSerializerOptions) ??
					throw new MojangException("Invalid data downloaded from launchermeta.mojang.com", 0);
			}
		}
	}
}
