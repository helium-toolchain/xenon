using System;
using System.Text.Json.Serialization;

namespace Xenon.InstallerLoader.Metadata
{
	public class InstallerData
	{
		[JsonPropertyName("installerId")]
		public String InstallerId { get; set; }

		[JsonPropertyName("installerName")]
		public String InstallerName { get; set; }

		[JsonPropertyName("description")]
		public String Description { get; set; }

		[JsonPropertyName("environment")]
		[JsonConverter(typeof(EnvironmentJsonConverter))]
		public InstallerEnvironment Environment { get; set; }

		[JsonPropertyName("assemblyFileName")]
		public String AssemblyFileName { get; set; }


		[JsonPropertyName("version")]
		[JsonConverter(typeof(VersionJsonConverter))]
		public Xenon.TypeLib.Version Version { get; set; }

		[JsonPropertyName("sources")]
		public Uri Sources { get; set; }

		[JsonPropertyName("issues")]
		public Uri Issues { get; set; }

		[JsonPropertyName("homepage")]
		public Uri Homepage { get; set; }


		[JsonPropertyName("depends")]
		public String[] Depends { get; set; }

		[JsonPropertyName("breaks")]
		public String[] Incompatible { get; set; }

		[JsonPropertyName("recommends")]
		public String[] Recommends { get; set; }

		[JsonPropertyName("author")]
		public String[] Authors { get; set; }
	}
}
