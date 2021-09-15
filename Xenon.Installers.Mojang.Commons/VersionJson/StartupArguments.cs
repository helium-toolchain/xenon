using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	public class StartupArguments
	{
		[JsonPropertyName("game")]
		public List<Argument> GameArguments { get; set; }

		[JsonPropertyName("jvm")]
		public List<Argument> JvmArguments { get; set; }
	}
}
