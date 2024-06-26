﻿using Andor.Domain.Onboarding.Registrations;
using Andor.Domain.Onboarding.Registrations.Repositories;
using Andor.Domain.Onboarding.Registrations.ValueObjects;
using Andor.Domain.SeedWork.Repositories.ResearchableRepository;
using Andor.Infrastructure.Repositories.Common;
using Andor.Infrastructure.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace Andor.Infrastructure.Onboarding.Repositories.Registrations;

public class QueriesRegistrationRepository(PrincipalContext context) :
    QueryHelper<Registration, RegistrationId>(context),
    IQueriesRegistrationRepository
{
    public async Task<Registration?> GetByEmailAsync(MailAddress email, CancellationToken cancellationToken)
    => await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Equals(email), cancellationToken);

    public Task<SearchOutput<Registration>> SearchAsync(SearchInput input, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
