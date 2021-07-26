using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
	}
}
