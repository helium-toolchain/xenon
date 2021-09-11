using System;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.Launchermeta
{
	public class Version
	{
		[JsonPropertyName("id")]
		public String VersionId { get; set; }

		[JsonPropertyName("type")]
		[JsonConverter(typeof(ReleaseTypeConverter))]
		public ReleaseType ReleaseType { get; set; }

		[JsonPropertyName("url")]
		public String Url { get; set; }

		[JsonPropertyName("time")]
		public DateTime Time { get; set; }

		[JsonPropertyName("releaseTime")]
		public DateTime ReleaseTime { get; set; }
	}
}
