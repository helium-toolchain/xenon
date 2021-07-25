using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.Launchermeta
{
	internal class LauncherMain
	{
		[JsonPropertyName("latest")]
		public Latest LatestVersions { get; set; }

		[JsonPropertyName("versions")]
		public Version[] Versions { get; set; }
	}
}
