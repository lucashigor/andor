﻿using Andor.Application.Dto.Administrations.Configurations.Responses;
using Andor.Application.Dto.Common.Requests;
using Andor.Domain.Entities.Admin.Configurations.Repository;
using Mapster;
using MediatR;

namespace Andor.Application.Administrations.Configurations.Queries;

public record ListConfigurationsQuery
    (int Page, int PerPage, string? Search, string? Sort, SearchOrder Dir)
    : PaginatedListInput(Page, PerPage, Search, Sort, Dir),
    IRequest<ListConfigurationsOutput>;

public class ListConfigurationsQueryHandler(IQueriesConfigurationRepository configurationRepository)
    : IRequestHandler<ListConfigurationsQuery, ListConfigurationsOutput>
{
    public async Task<ListConfigurationsOutput> Handle(ListConfigurationsQuery request, CancellationToken cancellationToken)
    {
        var searchOutput = await configurationRepository.SearchAsync(
            new(
                request.Page,
                request.PerPage,
                request.Search,
                request.Sort,
                (Domain.SeedWork.Repository.ISearchableRepository.SearchOrder)request.Dir
            ),
            cancellationToken
        );

        return searchOutput.Adapt<ListConfigurationsOutput>();
    }
}