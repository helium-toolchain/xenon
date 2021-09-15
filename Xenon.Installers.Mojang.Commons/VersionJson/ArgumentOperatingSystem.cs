using System;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	public class ArgumentOperatingSystem
	{
		[JsonPropertyName("name")]
		public String Name { get; set; }

		[JsonPropertyName("version")]
		public String Version { get; set; }
	}
}
