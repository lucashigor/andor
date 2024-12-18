﻿using Andor.Application.Common.Interfaces;
using Andor.Domain.Engagement.Budget.Accounts.Accounts;
using Andor.Domain.Engagement.Budget.Accounts.Accounts.Repositories;
using Andor.Domain.Engagement.Budget.Accounts.Accounts.ValueObjects;
using Andor.Domain.SeedWork.Repositories.ResearchableRepository;
using Andor.Infrastructure.Repositories.Common;
using Andor.Infrastructure.Repositories.Context;
using System.Linq.Expressions;

namespace Andor.Infrastructure.Engagement.Budget.Repositories.Queries;

public class QueriesAccountRepository :
        QueryHelper<Account, AccountId>, IQueriesAccountRepository
{
    public QueriesAccountRepository(PrincipalContext context,
        ICurrentUserService _currentUserService) : base(context)
    {
        loggedUserFilter = x => x.Users.Any(z => z.UserId == _currentUserService.User.UserId);
    }

    public Task<SearchOutput<Account>> SearchAsync(SearchInput input, CancellationToken cancellationToken)
    {
        Expression<Func<Account, bool>> where = x => true;

        if (!string.IsNullOrWhiteSpace(input.Search))
            where = x => x.Name.Contains(input.Search, StringComparison.CurrentCultureIgnoreCase);

        var items = GetManyPaginated(where,
            input.OrderBy,
            input.Order,
            input.Page,
            input.PerPage,
            out var total)
            .ToList();

        return Task.FromResult(new SearchOutput<Account>(input.Page, input.PerPage, total, items!));
    }
}
