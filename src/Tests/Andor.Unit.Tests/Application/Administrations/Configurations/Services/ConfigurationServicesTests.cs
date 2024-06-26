﻿using Andor.Application.Administrations.Configurations.Commands;
using Andor.Application.Administrations.Configurations.Services;
using Andor.Domain.Administrations.Configurations.Repository;
using Andor.Domain.Onboarding.Registrations.Repositories.Models;
using Andor.TestsUtil;
using Andor.Unit.Tests.Domain.Entities.Admin.Configurations;
using FluentAssertions;
using NSubstitute;

namespace Andor.Unit.Tests.Application.Administrations.Configurations.Services;

[Collection(nameof(ConfigurationTestFixture))]
public class ConfigurationServicesTests
{
    private readonly IQueriesConfigurationRepository _configurationRepository;

    public ConfigurationServicesTests()
    {
        _configurationRepository = Substitute.For<IQueriesConfigurationRepository>();
    }

    [Fact(DisplayName = nameof(HandleDatesWithEmptyDatabaseAsync))]
    [Trait("Domain", "Configuration - DateValidationServices")]
    public async Task HandleDatesWithEmptyDatabaseAsync()
    {
        var validData = ConfigurationFixture.GetValidConfiguration();
        var app = GetApp();

        var _notifier = await app.Handle(validData, CancellationToken.None);

        _notifier.Errors.Should().BeEmpty();
    }

    [Fact(DisplayName = nameof(HandleDatesWithSameNameClosedBeforeDatabaseAsync))]
    [Trait("Domain", "Configuration - DateValidationServices")]
    public async Task HandleDatesWithSameNameClosedBeforeDatabaseAsync()
    {
        var validData = ConfigurationFixture.GetValidConfiguration();

        _configurationRepository.GetByNameAndStatusAsync(Arg.Is<SearchConfigurationInput>(name => name.Name == validData.Name),
            Arg.Any<CancellationToken>()).Returns([]);

        var app = GetApp();

        var _notifier = await app.Handle(validData, CancellationToken.None);

        _notifier.Errors.Should().BeEmpty();
    }

    [Fact(DisplayName = nameof(HandleDatesWithSameNameStartsAfterDatabaseAsync))]
    [Trait("Domain", "Configuration - DateValidationServices")]
    public async Task HandleDatesWithSameNameStartsAfterDatabaseAsync()
    {
        var validData = ConfigurationFixture.GetValidConfiguration();

        var beforeConfig = ConfigurationFixture.LoadConfiguration(new BaseConfiguration(
            Name: validData.Name,
            Value: validData.Value,
            Description: validData.Description,
            StartDate: validData.ExpireDate!.Value.AddDays(10),
            ExpireDate: validData.ExpireDate.Value.AddDays(20)
        ));

        _configurationRepository.GetByNameAndStatusAsync(Arg.Is<SearchConfigurationInput>(name => name.Name == validData.Name),
            Arg.Any<CancellationToken>()).Returns([beforeConfig]);

        var app = GetApp();

        var _notifier = await app.Handle(validData, CancellationToken.None);

        _notifier.Errors.Should().BeEmpty();
    }

    [Fact(DisplayName = nameof(HandleDatesWithSameNameOpeningDuringDatabaseAsync))]
    [Trait("Domain", "Configuration - DateValidationServices")]
    public async Task HandleDatesWithSameNameOpeningDuringDatabaseAsync()
    {
        var validData = ConfigurationFixture.GetValidConfiguration();

        var beforeConfig = ConfigurationFixture.LoadConfiguration(new BaseConfiguration(
            Name: validData.Name,
            Value: validData.Value,
            Description: validData.Description,
            StartDate: validData.StartDate.AddDays(-3),
            ExpireDate: validData.StartDate.AddDays(1)
        ));

        _configurationRepository.GetByNameAndStatusAsync(Arg.Is<SearchConfigurationInput>(name => name.Name == validData.Name),
            Arg.Any<CancellationToken>()).Returns([beforeConfig]);

        var app = GetApp();
        var _notifier = await app.Handle(validData, CancellationToken.None);

        _notifier.Errors.Should().HaveCount(1);
        _notifier.Errors.First().Code.Should().Be(Andor.Application.Dto.Common.ApplicationsErrors.Errors.ThereWillCurrentConfigurationStartDate().Code);
        _notifier.Errors.First().Message.Should().Be(Andor.Application.Dto.Common.ApplicationsErrors.Errors.ThereWillCurrentConfigurationStartDate().Message);
    }

    [Fact(DisplayName = nameof(HandleDatesWithSameNameClosingDuringDatabaseAsync))]
    [Trait("Domain", "Configuration - DateValidationServices")]
    public async Task HandleDatesWithSameNameClosingDuringDatabaseAsync()
    {
        var validData = ConfigurationFixture.GetValidConfiguration();

        var beforeConfig = ConfigurationFixture.LoadConfiguration(new BaseConfiguration(
            Name: validData.Name,
            Value: validData.Value,
            Description: validData.Description,
            StartDate: validData!.ExpireDate!.Value.AddDays(-1),
            ExpireDate: validData!.ExpireDate!.Value.AddDays(1)
        ));

        _configurationRepository.GetByNameAndStatusAsync(Arg.Is<SearchConfigurationInput>(name => name.Name == validData.Name),
            Arg.Any<CancellationToken>()).Returns([beforeConfig]);

        var app = GetApp();
        var _notifier = await app.Handle(validData, CancellationToken.None);

        _notifier.Errors.Should().HaveCount(1);
        _notifier.Errors.First().Code.Should().Be(Andor.Application.Dto.Common.ApplicationsErrors.Errors.ThereWillCurrentConfigurationEndDate().Code);
        _notifier.Errors.First().Message.Should().Be(Andor.Application.Dto.Common.ApplicationsErrors.Errors.ThereWillCurrentConfigurationEndDate().Message);
    }

    [Fact(DisplayName = nameof(HandleDatesWithSameNameDuringDatabaseAsync))]
    [Trait("Domain", "Configuration - DateValidationServices")]
    public async Task HandleDatesWithSameNameDuringDatabaseAsync()
    {
        var validData = ConfigurationFixture.GetValidConfiguration();

        var beforeConfig = ConfigurationFixture.LoadConfiguration(new BaseConfiguration(
            Name: validData.Name,
            Value: validData.Value,
            Description: validData.Description,
            StartDate: validData.StartDate.AddDays(-3),
            ExpireDate: validData!.ExpireDate!.Value.AddDays(3)
        ));

        _configurationRepository.GetByNameAndStatusAsync(Arg.Is<SearchConfigurationInput>(name => name.Name == validData.Name),
            Arg.Any<CancellationToken>()).Returns([beforeConfig]);

        var app = GetApp();
        var _notifier = await app.Handle(validData, CancellationToken.None);

        _notifier.Errors.Should().HaveCount(2);
        _notifier.Errors.First().Code.Should().Be(Andor.Application.Dto.Common.ApplicationsErrors.Errors.ThereWillCurrentConfigurationStartDate().Code);
        _notifier.Errors.First().Message.Should().Be(Andor.Application.Dto.Common.ApplicationsErrors.Errors.ThereWillCurrentConfigurationStartDate().Message);

        _notifier.Errors.Last().Code.Should().Be(Andor.Application.Dto.Common.ApplicationsErrors.Errors.ThereWillCurrentConfigurationEndDate().Code);
        _notifier.Errors.Last().Message.Should().Be(Andor.Application.Dto.Common.ApplicationsErrors.Errors.ThereWillCurrentConfigurationEndDate().Message);
    }

    private ConfigurationServices GetApp()
    {
        return new ConfigurationServices(_configurationRepository);
    }
}