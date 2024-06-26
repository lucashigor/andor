﻿using Andor.Application.Common.Interfaces;
using MassTransit;

namespace Andor.Infrastructure.Messaging.Producers;

public class SendMessagePublisher(IPublishEndpoint bus) : IMessageSenderInterface
{
    private readonly IPublishEndpoint _bus = bus;

    public async Task PubSubSendAsync(object data, CancellationToken cancellationToken)
    {
        await _bus.Publish(data, cancellationToken);
    }
}
