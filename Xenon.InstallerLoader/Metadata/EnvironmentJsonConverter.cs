using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Xenon.InstallerLoader.Metadata
{
	public class EnvironmentJsonConverter : JsonConverter<InstallerEnvironment>
	{
		public override InstallerEnvironment Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => reader.GetString().ToLower() switch
		{
			"client" => InstallerEnvironment.Client,
			"server" => InstallerEnvironment.Server,
			_ => throw new InvalidDataException($"Invalid installer environment {reader.GetString()}")
		};
		public override void Write(Utf8JsonWriter writer, InstallerEnvironment value, JsonSerializerOptions options) => writer.WriteStringValue(value switch
		{
			InstallerEnvironment.Client => "client",
			InstallerEnvironment.Server => "server",
			_ => throw new InvalidProgramException($"Enum InstallerEnvironment only contains two options, a third one was called.")
		});
	}
}
