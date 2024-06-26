﻿using Andor.Domain.Onboarding.Registrations.ValueObjects;
using Andor.Domain.SeedWork.Repositories.ResearchableRepository;
using System.Net.Mail;

namespace Andor.Domain.Onboarding.Registrations.Repositories;

public interface IQueriesRegistrationRepository :
    IResearchableRepository<Registration, RegistrationId, SearchInput>
{
    Task<Registration?> GetByEmailAsync(MailAddress email, CancellationToken cancellationToken);
}
