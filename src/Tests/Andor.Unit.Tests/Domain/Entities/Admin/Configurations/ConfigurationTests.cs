﻿using Andor.Application.Administrations.Configurations.Commands;
using Andor.Domain.Administrations.Configurations;
using Andor.Domain.Administrations.Configurations.Events;
using Andor.Domain.Administrations.Configurations.ValueObjects;
using Andor.Domain.Common.ValuesObjects;
using Andor.TestsUtil;
using Andor.Unit.Tests.Domain.Entities.Admin.Configurations.Helpers;
using FluentAssertions;

namespace Andor.Unit.Tests.Domain.Entities.Admin.Configurations;

[Collection(nameof(ConfigurationTestFixture))]
public class ConfigurationTests()
{
    [Fact(DisplayName = nameof(NewConfigurationValidInputShouldNotHaveNotifications))]
    [Trait("Domain", "Configuration - Validation")]
    public void NewConfigurationValidInputShouldNotHaveNotifications()
    {
        // Act
        var (result, config) = Configuration.New(
                name: ConfigurationFixture.GetValidName(),
                value: ConfigurationFixture.GetValidValue(),
                description: ConfigurationFixture.GetValidDescription(),
                startDate: ConfigurationFixture.GetValidStartDate(ConfigurationState.Awaiting),
                expireDate: ConfigurationFixture.GetValidExpireDate(ConfigurationState.Awaiting),
                userId: Guid.NewGuid().ToString());

        result.IsSuccess.Should().BeTrue();

        config.Should().NotBeNull();

        // Assert
        config!.Events.Should().Contain(x => x.GetType() == typeof(ConfigurationCreatedDomainEvent),
            "New configuration should raise Created Domain Event");
    }

    [Theory(DisplayName = nameof(ValidConfigurationStatus))]
    [Trait("Domain", "Configuration - Validation")]
    [MemberData(nameof(TestInvalidDataGenerator.ValidConfigurationStatusTestData), MemberType = typeof(TestInvalidDataGenerator))]
    public void ValidConfigurationStatus(int startOffsetMonths, int? expireOffsetMonths, ConfigurationState expectedStatus)
    {
        // Arrange
        DateTime startDate = DateTime.UtcNow.AddMonths(startOffsetMonths);
        DateTime? expireDate = expireOffsetMonths is null ? null : DateTime.UtcNow.AddMonths(expireOffsetMonths.Value);

        // Act
        var configuration = ConfigurationFixture.LoadConfiguration(
            new BaseConfiguration(
                Name: ConfigurationFixture.GetValidName(),
                Value: ConfigurationFixture.GetValidValue(),
                Description: ConfigurationFixture.GetValidDescription(),
                StartDate: startDate,
                ExpireDate: expireDate
            ));

        // Assert
        configuration.State.Should().Be(expectedStatus);
    }

    [Theory(DisplayName = nameof(ValidationErrorsOnNewConfiguration))]
    [Trait("Domain", "Configuration - Validation")]
    [MemberData(nameof(TestInvalidDataGenerator.GetPersonFromDataGenerator), MemberType = typeof(TestInvalidDataGenerator))]
    public void ValidationErrorsOnNewConfiguration(BaseConfiguration inputConfig, DomainErrorCode error, string fieldName)
    {
        var (result, config) = Configuration.New(
            name: inputConfig.Name,
            value: inputConfig.Value,
            description: inputConfig.Description,
            startDate: inputConfig.StartDate,
            expireDate: inputConfig.ExpireDate,
            Guid.NewGuid().ToString());

        result.IsFailure.Should().BeTrue();

        config.Should().BeNull();

        result!.Errors.Should().Contain(x => x.Error == error);
        result!.Errors.Should().Contain(x => x.FieldName.Equals(fieldName, StringComparison.InvariantCultureIgnoreCase));
    }

    [Theory(DisplayName = nameof(NotPossibleToChangeDataToExpiredConfiguration))]
    [Trait("Domain", "Configuration - Validation")]
    [MemberData(nameof(TestInvalidDataGenerator.UpdateWithErrorOnExpiredConfig), MemberType = typeof(TestInvalidDataGenerator))]
    public void NotPossibleToChangeDataToExpiredConfiguration(
        UpdateWithError updateWithError)
    {
        var config = ConfigurationFixture.LoadConfiguration(updateWithError.ConfigurationStatus);

        config.State.Should().Be(updateWithError.ConfigurationStatus);

        // Act
        var result = config.Update(
            name: updateWithError.Name ?? config.Name,
            value: updateWithError.Value ?? config.Value,
            description: updateWithError.Description ?? config.Description,
            startDate: updateWithError.StartDate ?? config.StartDate,
            expireDate: updateWithError.ExpireDate ?? config.ExpireDate
        );

        result!.Errors.Should().Contain(x => x.Error == updateWithError.Error, updateWithError.Because);
        result!.Errors.Should().Contain(x => x.FieldName.Equals(updateWithError.FieldName,
            StringComparison.InvariantCultureIgnoreCase), updateWithError.Because);

        // Assert
        config!.Events.Should().NotContain(x => x.GetType() == typeof(ConfigurationUpdatedDomainEvent),
            "Update with error should not publish event");
    }

    [Fact(DisplayName = nameof(DeleteConfigurationInAwaiting))]
    [Trait("Domain", "Configuration - Validation")]
    public void DeleteConfigurationInAwaiting()
    {
        // Arrange
        var config = ConfigurationFixture.LoadConfiguration(ConfigurationState.Awaiting);

        config.State.Should().Be(ConfigurationState.Awaiting);

        config.Should().NotBeNull();

        // Act
        var result = config.Delete();

        // Assert
        config.IsDeleted.Should().BeTrue();
        result!.Errors.Should().BeEmpty();
        config!.Events.Should().Contain(x => x.GetType() == typeof(ConfigurationDeletedDomainEvent));
        result!.IsFailure.Should().BeFalse();
    }

    [Fact(DisplayName = nameof(DeleteConfigurationInActive))]
    [Trait("Domain", "Configuration - Validation")]
    public void DeleteConfigurationInActive()
    {
        // Arrange
        var config = ConfigurationFixture.LoadConfiguration(ConfigurationState.Active);

        config.State.Should().Be(ConfigurationState.Active);

        config.Should().NotBeNull();

        // Act
        var result = config.Delete();

        // Assert
        config.IsDeleted.Should().BeFalse();
        result!.Warnings.Should().Contain(x => x.Error == DomainErrorCode.SetExpireDateToToday);
        result!.IsFailure.Should().BeFalse();
    }

    [Fact(DisplayName = nameof(DeleteConfigurationInExpired))]
    [Trait("Domain", "Configuration - Validation")]
    public void DeleteConfigurationInExpired()
    {
        // Arrange
        var config = ConfigurationFixture.LoadConfiguration(ConfigurationState.Expired);

        config.State.Should().Be(ConfigurationState.Expired);

        config.Should().NotBeNull();

        // Act
        var result = config.Delete();

        // Assert
        config.IsDeleted.Should().BeFalse();
        result!.Errors.Should().Contain(x => x.Error == DomainErrorCode.ErrorOnDelete);
        result!.IsFailure.Should().BeTrue();
    }
}
