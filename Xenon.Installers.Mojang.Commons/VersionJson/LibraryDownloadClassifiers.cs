﻿using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	public class LibraryDownloadClassifiers
	{
		[JsonPropertyName("javadoc")]
		public LibraryArtifact Javadoc { get; set; }

		[JsonPropertyName("natives-linux")]
		public LibraryArtifact LinuxNatives { get; set; }

		[JsonPropertyName("natives-windows")]
		public LibraryArtifact WindowsNatives { get; set; }

		[JsonPropertyName("sources")]
		public LibraryArtifact Sources { get; set; }
	}
}
