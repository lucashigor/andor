﻿using Andor.Application.Dto.Administrations.Configurations.Requests;
using Andor.Domain.Administrations.Configurations.ValueObjects;
using Andor.TestsUtil;

namespace Andor.Unit.Tests.Domain.Entities.Admin.Configurations;

public class ConfigurationTestFixture
{
    public static BaseConfiguration GetBaseConfiguration(string? name)
        => GetBaseConfiguration(name, null!, null!, null!, null!);
    public static BaseConfiguration GetBaseConfiguration(string? name, string? value)
        => GetBaseConfiguration(name, value, null!, null!, null!);
    public static BaseConfiguration GetBaseConfiguration(string? name,
        string? value,
        string? description,
        DateTime? startDate,
        DateTime? expireDate)
        => new(
            Name: name ?? ConfigurationFixture.GetValidName(),
            Value: value ?? ConfigurationFixture.GetValidValue(),
            Description: description ?? ConfigurationFixture.GetValidDescription(),
            StartDate: startDate ?? ConfigurationFixture.GetValidStartDate(ConfigurationState.Awaiting),
            ExpireDate: expireDate ?? ConfigurationFixture.GetValidExpireDate(ConfigurationState.Awaiting)
        );

    [CollectionDefinition(nameof(ConfigurationTestFixture))]
    public class ConfigurationTestFixtureCollection : ICollectionFixture<ConfigurationTestFixture>
    {
    }
}
