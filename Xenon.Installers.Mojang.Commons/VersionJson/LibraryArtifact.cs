using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
