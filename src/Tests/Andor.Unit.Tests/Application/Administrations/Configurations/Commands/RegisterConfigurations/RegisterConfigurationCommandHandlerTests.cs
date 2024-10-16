﻿namespace Andor.Unit.Tests.Application.Administrations.Configurations.Commands.RegisterConfigurations;

using Andor.Application.Administrations.Configurations.Commands.RegisterConfigurations;
using Andor.Application.Administrations.Configurations.Services;
using Andor.Application.Common.Interfaces;
using Andor.Application.Dto.Administrations.Configurations.Responses;
using Andor.Application.Dto.Common.Responses;
using Andor.Domain.Administrations.Configurations;
using Andor.Domain.Administrations.Configurations.Repository;
using Andor.TestsUtil;
using Andor.Unit.Tests.Domain.Entities.Admin.Configurations;
using FluentAssertions;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

[Collection(nameof(ConfigurationTestFixture))]
public class RegisterConfigurationCommandHandlerTests(ConfigurationTestFixture fixture)
{
    private readonly ICommandsConfigurationRepository _configurationRepository = Substitute.For<ICommandsConfigurationRepository>();
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
    private readonly IConfigurationServices _configurationServices = Substitute.For<IConfigurationServices>();
    private readonly ConfigurationTestFixture _fixture = fixture;

    [Fact(DisplayName = nameof(HandleRegisterConfigurationAsync))]
    [Trait("Domain", "Configuration - RegisterConfigurationCommandHandler")]
    public async Task HandleRegisterConfigurationAsync()
    {
        var app = GetApp();

        var command = GetCommand(null);

        _configurationServices.Handle(Arg.Any<Configuration>(),
            Arg.Any<CancellationToken>()).Returns(ApplicationResult<ConfigurationOutput>.Success());

        var _notifier = await app.Handle(command, CancellationToken.None);

        _notifier.Errors.Should().BeEmpty();
        await _configurationServices.Received(1).Handle(Arg.Any<Configuration>(), Arg.Any<CancellationToken>());
        await _unitOfWork.Received(1).CommitAsync(Arg.Any<CancellationToken>());
        await _configurationRepository.Received(1).InsertAsync(Arg.Any<Configuration>(), Arg.Any<CancellationToken>());
    }

    [Fact(DisplayName = nameof(HandleRegisterConfigurationAsync_WithError))]
    [Trait("Domain", "Configuration - RegisterConfigurationCommandHandler")]
    public async Task HandleRegisterConfigurationAsync_WithError()
    {
        var app = GetApp();

        var command = GetCommand("");

        var _notifier = await app.Handle(command, CancellationToken.None);

        _notifier.Errors.Should().NotBeEmpty();
        await _configurationServices.Received(0).Handle(Arg.Any<Configuration>(), Arg.Any<CancellationToken>());
        await _unitOfWork.Received(0).CommitAsync(Arg.Any<CancellationToken>());
        await _configurationRepository.Received(0).InsertAsync(Arg.Any<Configuration>(), Arg.Any<CancellationToken>());
    }

    private static RegisterConfigurationCommand GetCommand(string? name)
        => new(ConfigurationTestFixture.GetBaseConfiguration(name));

    private RegisterConfigurationCommandHandler GetApp()
        => new(_configurationRepository,
                _unitOfWork,
                _configurationServices,
                GeneralFixture.GetUserService());
}
