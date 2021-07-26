using System;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	internal class Argument
	{
		[JsonPropertyName("rules")]
		public ArgumentRule[] Rules { get; set; }

		[JsonPropertyName("value")]
		public String[] Values { get; set; }
	}
}
