using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Xenon.InstallerLoader.Metadata
{
	class VersionJsonConverter : JsonConverter<Xenon.TypeLib.Version>
	{
		public override TypeLib.Version Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			String[] sv = reader.GetString().Split('.');

			if(sv.Length != 3)
			{
				throw new ArgumentException("Versions must have three numbers");
			}

			return new TypeLib.Version
			{
				Major = Convert.ToUInt16(sv[0]),
				Minor = Convert.ToUInt16(sv[1]),
				Hotfix = Convert.ToUInt16(sv[2])
			};
		}
		public override void Write(Utf8JsonWriter writer, TypeLib.Version value, JsonSerializerOptions options) 
			=> writer.WriteStringValue($"{value.Major}.{value.Minor}.{value.Hotfix}");
	}
}
