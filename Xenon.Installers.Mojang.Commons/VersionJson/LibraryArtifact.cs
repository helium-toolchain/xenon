using System;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	public class LibraryArtifact
	{
		[JsonPropertyName("path")]
		public String Path { get; set; }

		[JsonPropertyName("sha1")]
		public String Sha1 { get; set; }

		[JsonPropertyName("size")]
		public Int64 Size { get; set; }

		[JsonPropertyName("url")]
		public String Url { get; set; }
	}
}
