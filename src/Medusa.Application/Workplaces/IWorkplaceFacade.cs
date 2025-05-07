using Medusa.Presentation.Workplaces;

namespace Medusa.Application.Workplaces;

public interface IWorkplaceFacade
{
    /// <summary>
    ///     Retrieves all workplaces associated with a specific tenant.
    /// </summary>
    /// <param name="tenantId">The unique identifier of the tenant whose workplaces to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of <see cref="WorkplaceModel" /> objects representing all workplaces in the system.</returns>
    Task<IReadOnlyCollection<WorkplaceModel>> GetWorkplacesAsync(Guid tenantId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a workplace by its unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier to check the workplace against.</param>
    /// <param name="workplaceId">The unique identifier of the workplace to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="WorkplaceModel" /> object representing the workplace with the specified identifier, or null if not found.</returns>
    Task<WorkplaceModel> GetWorkplaceAsync(Guid tenantId, Guid workplaceId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Creates a new workplace.
    /// </summary>
    /// <param name="tenantId">The unique identifier to check the workplace against.</param>
    /// <param name="model">The <see cref="CreateWorkplaceModel" /> object representing the workplace to created.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The created <see cref="WorkplaceModel" /> object.</returns>
    Task<WorkplaceModel> CreateWorkplaceAsync(Guid tenantId, CreateWorkplaceModel model, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing workplace.
    /// </summary>
    /// <param name="tenantId">The unique identifier to check the workplace against.</param>
    /// <param name="workplaceId">The unique identifier of the workplace to update.</param>
    /// <param name="model">The <see cref="UpdateWorkplaceModel" /> object representing the workplace to update.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    Task UpdateWorkplaceAsync(Guid tenantId, Guid workplaceId, UpdateWorkplaceModel model, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a workplace by its unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier to check the workplace against.</param>
    /// <param name="workplaceId">The unique identifier of the workplace to delete.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    Task<bool> DeleteWorkplaceAsync(Guid tenantId, Guid workplaceId, CancellationToken cancellationToken = default);
}
