﻿using Andor.Domain.Common.ValuesObjects;

namespace Andor.Unit.Tests.Domain.ValuesObjects;

public class NotificationTests
{
    [Fact]
    public void ToString_ReturnsExpectedString()
    {
        // Arrange
        var notification = new Notification("FieldName", "Error Message",
            DomainErrorCode.Validation);

        // Act
        var result = notification.ToString();

        // Assert
        Assert.Equal($"{DomainErrorCode.Validation}: Message - Error Message", result);
    }
}
