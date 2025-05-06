using Medusa.Presentation.Tenants;

namespace Medusa.Application;

public interface ITenantFacade
{
    /// <summary>
    ///     Retrieves all tenants.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of <see cref="TenantModel" /> objects representing all tenants in the system.</returns>
    Task<IReadOnlyCollection<TenantModel>> GetTenantsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a tenant by its unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier of the tenant to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="TenantModel" /> object representing the tenant with the specified identifier, or null if not found.</returns>
    Task<TenantModel?> GetTenantAsync(Guid tenantId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Creates a new tenant.
    /// </summary>
    /// <param name="createTenantModel">The <see cref="CreateTenantModel" /> object representing the tenant to create.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The created <see cref="TenantModel" /> object.</returns>
    Task<TenantModel> CreateTenantAsync(CreateTenantModel createTenantModel, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing tenant.
    /// </summary>
    /// <param name="tenantId">The unique identifier of the tenant to update.</param>
    /// <param name="updateTenantModel">The <see cref="UpdateTenantModel" /> object representing the tenant to update.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    Task UpdateTenantAsync(Guid tenantId, UpdateTenantModel updateTenantModel, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a tenant by its unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier of the tenant to delete.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    Task<bool> DeleteTenantAsync(Guid tenantId, CancellationToken cancellationToken = default);
}
