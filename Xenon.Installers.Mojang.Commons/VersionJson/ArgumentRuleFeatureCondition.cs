using System;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	public class ArgumentRuleFeatureCondition
	{
		[JsonPropertyName("is_demo_user")]
		public Boolean DemoUser { get; set; }

		[JsonPropertyName("has_custom_resolution")]
		public Boolean CustomResolution { get; set; }
	}
}
