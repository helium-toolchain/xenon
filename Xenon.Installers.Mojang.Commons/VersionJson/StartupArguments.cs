using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	internal class StartupArguments
	{
		[JsonPropertyName("game")]
		public List<Argument> GameArguments { get; set; }

		[JsonPropertyName("jvm")]
		public List<Argument> JvmArguments { get; set; }
	}
}
