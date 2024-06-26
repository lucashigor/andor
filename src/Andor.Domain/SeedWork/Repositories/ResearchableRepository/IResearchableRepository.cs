﻿namespace Andor.Domain.SeedWork.Repositories.ResearchableRepository;

public interface IResearchableRepository<TEntity, TEntityId, TSearchInput>
    where TEntity : Entity<TEntityId>
    where TSearchInput : SearchInput
    where TEntityId : IEquatable<TEntityId>
{
    Task<TEntity?> GetByIdAsync(TEntityId id, CancellationToken cancellationToken);

    Task<SearchOutput<TEntity>> SearchAsync(TSearchInput input, CancellationToken cancellationToken);
}
