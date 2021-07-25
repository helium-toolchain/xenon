using System;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.Launchermeta
{
	internal class Latest
	{
		[JsonPropertyName("release")]
		public String LatestRelease { get; set; }

		[JsonPropertyName("snapshot")]
		public String LatestSnapshot { get; set; }
	}
}
