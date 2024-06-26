﻿using Andor.Domain.Common.ValuesObjects;
using Andor.Domain.Engagement.Budget.Accounts.Accounts.ValueObjects;
using Andor.Domain.Engagement.Budget.FinancialMovements.CashFlow;
using Andor.Domain.Engagement.Budget.FinancialMovements.CashFlow.ValueObjects;
using Andor.Domain.SeedWork.Repositories.CommandRepository;

namespace Andor.Domain.Engagement.Budget.Accounts.Accounts.Repositories;

public interface ICommandsCashFlowRepository : ICommandRepository<CashFlow, CashFlowId>
{
    Task<CashFlow?> GetCurrentOrPreviousCashFlowAsync(AccountId accountId, Year year, Month month, CancellationToken cancellationToken);
    Task<CashFlow?> GetCurrentOrNextCashFlowAsync(AccountId accountId, Year year, Month month, CancellationToken cancellationToken);
}
