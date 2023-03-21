using System.Text.Json;
using System.Text.Json.Protobuf.Tests;
using Google.Protobuf;
using Protobuf.System.Text.Json.Tests.Utils;
using Shouldly;
using SmartAnalyzers.ApprovalTestsExtensions;
using Xunit;

namespace Protobuf.System.Text.Json.Tests;

public class MessageWithByteStringsTests
{
    [Fact]
    public void Should_serialize_message_with_bytes()
    {
        // Arrange
        var msg = new MessageWithBytes()
        {
            BytesProperty = ByteString.CopyFrom(0x00, 0x01, 0x02, 0x03)
        };
    
        var jsonSerializerOptions = TestHelper.CreateJsonSerializerOptions();
    
        // Act
        var serialized = JsonSerializer.Serialize(msg, jsonSerializerOptions);
    
        // Assert
        var approver = new ExplicitApprover();
        approver.VerifyJson(serialized);
    }
    
    [Fact]
    public void Should_serialize_message_with_bytes_when_value_not_set()
    {
        // Arrange
        var msg = new MessageWithBytes();
    
        var jsonSerializerOptions = TestHelper.CreateJsonSerializerOptions();
    
        // Act
        var serialized = JsonSerializer.Serialize(msg, jsonSerializerOptions);
    
        // Assert
        var approver = new ExplicitApprover();
        approver.VerifyJson(serialized);
    }
    
    [Fact]
    public void Should_serialize_and_deserialize_message_with_bytes()
    {
        // Arrange
        var msg = new MessageWithBytes
        {
            BytesProperty = ByteString.CopyFrom(0x00, 0x01, 0x02, 0x03)
        };
        var jsonSerializerOptions = TestHelper.CreateJsonSerializerOptions();
    
        // Act
        var serialized = JsonSerializer.Serialize(msg, jsonSerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageWithBytes>(serialized, jsonSerializerOptions);
    
        // Assert
        deserialized.ShouldNotBeNull();
        deserialized.ShouldBeEquivalentTo(msg);
    }
    
    [Fact]
    public void Should_serialize_and_deserialize_message_with_bytes_when_value_is_not_set()
    {
        // Arrange
        var msg = new MessageWithBytes();
        var jsonSerializerOptions = TestHelper.CreateJsonSerializerOptions();
    
        // Act
        var serialized = JsonSerializer.Serialize(msg, jsonSerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageWithBytes>(serialized, jsonSerializerOptions);
    
        // Assert
        deserialized.ShouldNotBeNull();
        deserialized.ShouldBeEquivalentTo(msg);
    }
}