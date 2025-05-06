using Medusa.Domain.Tenants;
using Medusa.Presentation.Tenants;

namespace Medusa.Application;

public class TenantFacade : ITenantFacade
{
    private readonly ITenantRepository _tenantRepository;

    public TenantFacade(ITenantRepository tenantRepository)
    {
        _tenantRepository = tenantRepository;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<TenantModel>> GetTenantsAsync(CancellationToken cancellationToken = default)
    {
        var tenants = await _tenantRepository.GetTenantsAsync(cancellationToken);

        return tenants.Select(t => new TenantModel
        {
            Id = t.Id,
            Country = t.Country,
            Name = t.Name,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt
        }).ToList();
    }

    /// <inheritdoc />
    public async Task<TenantModel?> GetTenantAsync(Guid tenantId, CancellationToken cancellationToken = default)
    {
        var tenant = await _tenantRepository.GetTenantAsync(tenantId, cancellationToken);

        return tenant == null ? null : new TenantModel
        {
            Id = tenant.Id,
            Country = tenant.Country,
            Name = tenant.Name,
            CreatedAt = tenant.CreatedAt,
            UpdatedAt = tenant.UpdatedAt
        };
    }

    /// <inheritdoc />
    public async Task<TenantModel> CreateTenantAsync(CreateTenantModel createTenantModel, CancellationToken cancellationToken = default)
    {
        var tenant = new Tenant
        {
            Country = createTenantModel.Country,
            Name = createTenantModel.Name,
        };

        await _tenantRepository.AddTenantAsync(tenant, cancellationToken);

        return new TenantModel
        {
            Id = tenant.Id,
            Country = tenant.Country,
            Name = tenant.Name,
            CreatedAt = tenant.CreatedAt,
            UpdatedAt = tenant.UpdatedAt
        };
    }

    /// <inheritdoc />
    public async Task UpdateTenantAsync(Guid tenantId, UpdateTenantModel updateTenantModel, CancellationToken cancellationToken = default)
    {
        var tenant = await _tenantRepository.GetTenantAsync(tenantId, cancellationToken);

        if (tenant == null)
        {
            throw new KeyNotFoundException($"Tenant with unique identifier {tenantId} not found.");
        }

        tenant.Country = updateTenantModel.Country ?? tenant.Country;
        tenant.Name = updateTenantModel.Name ?? tenant.Name;

        await _tenantRepository.UpdateTenantAsync(tenant, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> DeleteTenantAsync(Guid tenantId, CancellationToken cancellationToken = default)
    {
        var tenant = await _tenantRepository.GetTenantAsync(tenantId, cancellationToken);

        if (tenant == null)
        {
            throw new KeyNotFoundException($"Tenant with unique identifier {tenantId} not found.");
        }

        var result = await _tenantRepository.DeleteTenantAsync(tenant.Id, cancellationToken);
        return result;
    }
}
