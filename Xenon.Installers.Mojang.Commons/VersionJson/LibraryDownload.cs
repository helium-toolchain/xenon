using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	public class LibraryDownload
	{
		[JsonPropertyName("artifact")]
		public LibraryArtifact Artifact { get; set; }

		[JsonPropertyName("classifiers")]
		public LibraryDownloadClassifiers Classifiers { get; set; }
	}
}
