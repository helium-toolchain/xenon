using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Xenon.Installers.Mojang.Commons.VersionJson
{
	internal class ArgumentConditionJsonConverter : JsonConverter<Argument>
	{
		public override Argument Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if(reader.TokenType == JsonTokenType.String)
			{
				return new Argument()
				{
					Values = new String[] { reader.GetString()! }
				};
			}

			if(reader.TokenType != JsonTokenType.StartObject)
			{
				throw new MojangException("Invalid JSON data - found neither string nor object trying to deserialize arguments", 3);
			}

			// we know its an object, proceed as object
			return JsonSerializer.Deserialize<Argument>(ref reader)!;
		}

		public override void Write(Utf8JsonWriter writer, Argument value, JsonSerializerOptions options) => throw new NotImplementedException();
	}
}
