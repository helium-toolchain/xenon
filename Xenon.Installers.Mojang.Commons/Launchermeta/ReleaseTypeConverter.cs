using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.Launchermeta
{
	internal class ReleaseTypeConverter : JsonConverter<ReleaseType>
	{
#pragma warning disable IDE0022
		public override ReleaseType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetString().ToLower() switch
			{
				"release" => ReleaseType.Release,
				"snapshot" => ReleaseType.Snapshot,
				"old_beta" => ReleaseType.Beta,
				"old_alpha" => ReleaseType.Alpha,
				"experimental" => ReleaseType.Experimental,
				_ => throw new MojangException("Unknown release type", 1)
			};
		}

		public override void Write(Utf8JsonWriter writer, ReleaseType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value switch
			{
				ReleaseType.Release => "release",
				ReleaseType.Snapshot => "snapshot",
				ReleaseType.Beta => "old_beta",
				ReleaseType.Alpha => "old_alpha",
				ReleaseType.Experimental => "experimental",
				_ => throw new InvalidProgramException("The called enum member does not actually exist.")
			});
		}
#pragma warning restore IDE0022
	}
}
