using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Xenon.Installers.MojangClient.Assets
{
	public class AssetIndex
	{
		public class AssetIndexObject
		{
			[JsonPropertyName("hash")]
			public String Hash { get; set; }

			[JsonPropertyName("size")]
			public UInt32 Size { get; set; }
		}

		[JsonPropertyName("objects")]
		public Dictionary<String, AssetIndexObject> Objects { get; set; }
	}
}
