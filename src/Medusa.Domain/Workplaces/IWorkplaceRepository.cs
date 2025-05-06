namespace Medusa.Domain.Workplaces;

/// <summary>
///     A repository interface for managing workplace entities.
/// </summary>
public interface IWorkplaceRepository
{
    /// <summary>
    ///     Retrieves all workplaces.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of <see cref="Workplace" /> objects representing all workplaces in the system.</returns>
    Task<IReadOnlyCollection<Workplace>> GetWorkplacesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves all workplaces associated with a specific tenant.
    /// </summary>
    /// <param name="tenantId">The unique identifier of the tenant whose workplaces to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of <see cref="Workplace" /> objects representing all workplaces associated with the specified tenant.</returns>
    Task<IReadOnlyCollection<Workplace>> GetWorkplacesAsync(Guid tenantId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a workplace by its unique identifier.
    /// </summary>
    /// <param name="workplaceId">The unique identifier of the workplace to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Workplace" /> object representing the workplace with the specified identifier, or null if not found.</returns>
    Task<Workplace?> GetWorkplaceAsync(Guid workplaceId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Adds a new workplace.
    /// </summary>
    /// <param name="workplace">The <see cref="Workplace" /> object representing the workplace to add.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The added <see cref="Workplace" /> object.</returns>
    Task<Workplace> AddWorkplaceAsync(Workplace workplace, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing workplace.
    /// </summary>
    /// <param name="workplace">The <see cref="Workplace" /> object representing the workplace to update.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    Task UpdateWorkplaceAsync(Workplace workplace, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a workplace by its unique identifier.
    /// </summary>
    /// <param name="workplaceId">The unique identifier of the workplace to delete.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    Task<bool> DeleteWorkplaceAsync(Guid workplaceId, CancellationToken cancellationToken = default);
}
