using System.Text.Json;
using System.Text.Json.Serialization;
using Google.Protobuf;

namespace Protobuf.System.Text.Json.WellKnownTypesConverters;

internal class BytesConverter : JsonConverter<ByteString>
{
    public override ByteString? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            return ByteString.FromBase64(reader.GetString());
        }
    
        return null;
    }
    
    public override void Write(Utf8JsonWriter writer, ByteString? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            writer.WriteBase64StringValue(value.Span);
        }
    }
}