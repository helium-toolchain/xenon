using System;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	public class Library
	{
		[JsonPropertyName("downloads")]
		public LibraryDownload Downloads { get; set; }

		[JsonPropertyName("name")]
		public String Name { get; set; }
	}
}
