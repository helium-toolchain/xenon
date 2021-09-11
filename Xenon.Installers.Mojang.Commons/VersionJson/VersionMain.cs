using System.Text.Json.Serialization;

using Xenon.Installers.Mojang.Commons.Launchermeta;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	internal class VersionMain
	{
		[JsonPropertyName("arguments")]
		public StartupArguments Arguments { get; set; }

		[JsonPropertyName("assetIndex")]
		public AssetIndex AssetsIndex { get; set; }

		[JsonPropertyName("assets")]
		public String Assets { get; set; }

		[JsonPropertyName("complianceLevel")]
		public UInt32 ComplianceLevel { get; set; }

		[JsonPropertyName("downloads")]
		public DownloadsWrapper Downloads { get; set; }

		[JsonPropertyName("id")]
		public String Version { get; set; }

		[JsonPropertyName("javaVersion")]
		public JavaVersion JavaVersion { get; set; }

		[JsonPropertyName("releaseTime")]
		public DateTimeOffset ReleaseTime { get; set; }

		[JsonConverter(typeof(ReleaseTypeConverter))]
		[JsonPropertyName("type")]
		public ReleaseType Type { get; set; }

		[JsonPropertyName("libraries")]
		public Library[] Libraries { get; set; }
	}
}
