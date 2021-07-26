using System;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	internal class AssetIndex
	{
		[JsonPropertyName("id")]
		public String Id { get; set; }

		[JsonPropertyName("sha1")]
		public String Sha1 { get; set; }

		[JsonPropertyName("size")]
		public UInt32 Size { get; set; }

		[JsonPropertyName("totalSize")]
		public UInt32 TotalSize { get; set; }

		[JsonPropertyName("url")]
		public String Url { get; set; }
	}
}
