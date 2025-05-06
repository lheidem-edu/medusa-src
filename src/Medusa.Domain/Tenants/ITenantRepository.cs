namespace Medusa.Domain.Tenants;

public interface ITenantRepository
{
    /// <summary>
    ///     Retrieves all tenants.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of <see cref="Tenant" /> objects representing all tenants in the system.</returns>
    Task<IReadOnlyCollection<Tenant>> GetTenantsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a tenant by its unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier of the tenant to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Tenant" /> object representing the tenant with the specified identifier, or null if not found.</returns>
    Task<Tenant?> GetTenantAsync(Guid tenantId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Adds a new tenant.
    /// </summary>
    /// <param name="tenant">The <see cref="Tenant" /> object representing the tenant to add.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The added <see cref="Tenant" /> object.</returns>
    Task<Tenant> AddTenantAsync(Tenant tenant, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing tenant.
    /// </summary>
    /// <param name="tenant">The <see cref="Tenant" /> object representing the tenant to update.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    Task UpdateTenantAsync(Tenant tenant, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a tenant by its unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier of the tenant to delete.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    Task<bool> DeleteTenantAsync(Guid tenantId, CancellationToken cancellationToken = default);
}
