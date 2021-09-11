using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	public class DownloadsWrapper
	{
		[JsonPropertyName("client")]
		public Download Client { get; set; }

		[JsonPropertyName("client_mappings")]
		public Download ClientMappings { get; set; }

		[JsonPropertyName("server")]
		public Download Server { get; set; }

		[JsonPropertyName("server_mappings")]
		public Download ServerMappings { get; set; }
	}
}
