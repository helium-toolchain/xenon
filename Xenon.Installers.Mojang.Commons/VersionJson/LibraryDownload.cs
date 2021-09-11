using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
