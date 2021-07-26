using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	internal class ArgumentOperatingSystem
	{
		[JsonPropertyName("name")]
		public String Name { get; set; }
	}
}
