using System;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	internal class ArgumentRule
	{
		[JsonPropertyName("action")]
		public String Action { get; set; }
		
		[JsonPropertyName("features")]
		public ArgumentRuleFeatureCondition FeatureCondition { get; set; }

		[JsonPropertyName("os")]
		public ArgumentOperatingSystem OperatingSystem { get; set; }
	}
}
