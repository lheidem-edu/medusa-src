using Medusa.Presentation.Workplaces;

namespace Medusa.Application;

public interface IWorkplaceFacade
{
    /// <summary>
    ///     Retrieves all workplaces.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of <see cref="WorkplaceModel" /> objects representing all workplaces in the system.</returns>
    Task<IReadOnlyCollection<WorkplaceModel>> GetWorkplacesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a workplace by its unique identifier.
    /// </summary>
    /// <param name="workplaceId">The unique identifier of the workplace to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="WorkplaceModel" /> object representing the workplace with the specified identifier, or null if not found.</returns>
    Task<WorkplaceModel?> GetWorkplaceAsync(Guid workplaceId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Creates a new workplace.
    /// </summary>
    /// <param name="createWorkplaceModel">The <see cref="CreateWorkplaceModel" /> object representing the workplace to created.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The created <see cref="WorkplaceModel" /> object.</returns>
    Task<WorkplaceModel> CreateWorkplaceAsync(CreateWorkplaceModel createWorkplaceModel, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing workplace.
    /// </summary>
    /// <param name="workplaceId">The unique identifier of the workplace to update.</param>
    /// <param name="updateWorkplaceModel">The <see cref="UpdateWorkplaceModel" /> object representing the workplace to update.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    Task UpdateWorkplaceAsync(Guid workplaceId, UpdateWorkplaceModel updateWorkplaceModel, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a workplace by its unique identifier.
    /// </summary>
    /// <param name="workplaceId">The unique identifier of the workplace to delete.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    Task<bool> DeleteWorkplaceAsync(Guid workplaceId, CancellationToken cancellationToken = default);
}
