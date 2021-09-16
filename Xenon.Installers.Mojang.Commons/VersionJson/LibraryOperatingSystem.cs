using System;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	public class LibraryOperatingSystem
	{
		[JsonPropertyName("name")]
		public String Name { get; set; }
	}
}
