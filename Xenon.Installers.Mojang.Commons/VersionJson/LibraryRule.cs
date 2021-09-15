using System;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	public class LibraryRule
	{
		[JsonPropertyName("action")]
		public String Action { get; set; }

		[JsonPropertyName("os")]
		public LibraryOperatingSystem OperatingSystem { get; set; }
	}
}
