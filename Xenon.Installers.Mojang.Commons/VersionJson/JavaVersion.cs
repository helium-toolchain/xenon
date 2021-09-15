using System;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	public class JavaVersion
	{
		[JsonPropertyName("component")]
		public String Component { get; set; }

		[JsonPropertyName("majorVersion")]
		public UInt32 Version { get; set; }
	}
}
