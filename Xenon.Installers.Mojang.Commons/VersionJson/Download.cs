using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	public class Download
	{
		[JsonPropertyName("sha1")]
		public String Sha1 { get; set; }

		[JsonPropertyName("size")]
		public UInt32 Size { get; set; }

		[JsonPropertyName("url")]
		public String Url { get; set; }
	}
}
