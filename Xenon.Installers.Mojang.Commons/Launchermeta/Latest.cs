using System;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.Launchermeta
{
	public class Latest
	{
		[JsonPropertyName("release")]
		public String LatestRelease { get; set; }

		[JsonPropertyName("snapshot")]
		public String LatestSnapshot { get; set; }
	}
}
