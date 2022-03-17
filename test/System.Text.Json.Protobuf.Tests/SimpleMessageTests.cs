using System.Text.Json.Protobuf.Tests.Utils;
using Shouldly;
using SmartAnalyzers.ApprovalTestsExtensions;
using Xunit;

namespace System.Text.Json.Protobuf.Tests;

public class SimpleMessageTests
{
    [Fact]
    public void Should_serialize_message_with_primitive_types()
    {
        // Arrange
        var msg = new SimpleMessage
        {
            Int32Property = 1,
            Int64Property = 2,
        };
        var jsonSerializerOptions = TestHelper.CreateJsonSerializerOptions();
        
        // Act
        var serialized = JsonSerializer.Serialize(msg, jsonSerializerOptions);

        // Assert
        var approver = new ExplicitApprover();
        approver.VerifyJson(serialized);
    }

    [Fact]
    public void Should_deserialize_message_with_primitive_types()
    {
        // Arrange
        var msg = new SimpleMessage
        {
            Int32Property = 1,
            Int64Property = 2,
        };
        var jsonSerializerOptions = TestHelper.CreateJsonSerializerOptions();

        // Act
        var serialized = JsonSerializer.Serialize(msg, jsonSerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SimpleMessage>(serialized, jsonSerializerOptions);

        // Assert
        deserialized.ShouldNotBeNull();
        deserialized.Int32Property.ShouldBe(msg.Int32Property);
        deserialized.Int64Property.ShouldBe(msg.Int64Property);
    }
}