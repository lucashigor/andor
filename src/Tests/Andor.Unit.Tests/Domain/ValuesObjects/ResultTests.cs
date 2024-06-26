﻿using Andor.Domain.Common.ValuesObjects;

namespace Andor.Unit.Tests.Domain.ValuesObjects;

public class ResultTests
{
    [Fact]
    public void Success_NoWarningsNoErrors_IsSuccessTrue()
    {
        // Arrange

        // Act
        var result = DomainResult.Success();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Empty(result.Warnings);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Success_WithWarnings_IsSuccessTrue()
    {
        // Arrange
        var warnings = new List<Notification>
        {
            new ("FieldName1", "Warning Message 1", DomainErrorCode.Validation),
            new ("FieldName2", "Warning Message 2", DomainErrorCode.Validation)
        };

        // Act
        var result = DomainResult.Success(warnings);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(warnings, result.Warnings);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Failure_WithErrorsAndWarnings_IsSuccessFalse()
    {
        // Arrange
        var errors = new List<Notification>
        {
            new ("FieldName1", "Error Message 1", DomainErrorCode.Validation),
            new ("FieldName2", "Error Message 2", DomainErrorCode.Validation)
        };
        var warnings = new List<Notification>
        {
            new ("FieldName3", "Warning Message 1", DomainErrorCode.Validation)
        };

        // Act
        var result = DomainResult.Failure(errors, warnings);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(errors, result.Errors);
        Assert.Equal(warnings, result.Warnings);
    }

    [Fact]
    public void Failure_WithErrorsOnly_IsSuccessFalse()
    {
        // Arrange
        var errors = new List<Notification>
        {
            new ("FieldName1", "Error Message 1", DomainErrorCode.Validation),
            new ("FieldName2", "Error Message 2", DomainErrorCode.Validation)
        };

        // Act
        var result = DomainResult.Failure(errors);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(errors, result.Errors);
        Assert.Empty(result.Warnings);
    }
}
