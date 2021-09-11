using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
