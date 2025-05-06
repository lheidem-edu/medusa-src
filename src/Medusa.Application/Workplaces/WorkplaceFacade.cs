using Medusa.Domain.Workplaces;
using Medusa.Presentation.Workplaces;

namespace Medusa.Application.Workplaces;

public class WorkplaceFacade : IWorkplaceFacade
{
    private readonly IWorkplaceRepository _workplaceRepository;

    public WorkplaceFacade(IWorkplaceRepository workplaceRepository)
    {
        _workplaceRepository = workplaceRepository;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<WorkplaceModel>> GetWorkplacesAsync(Guid tenantId, CancellationToken cancellationToken = default)
    {
        var workplaces = await _workplaceRepository.GetWorkplacesAsync(tenantId, cancellationToken);

        return workplaces.Select(w => new WorkplaceModel
        {
            Id = w.Id,
            TenantId = w.TenantId,
            Enabled = w.Enabled,
            Name = w.Name,
            CreatedAt = w.CreatedAt,
            UpdatedAt = w.UpdatedAt
        }).ToList();
    }

    /// <inheritdoc />
    public async Task<WorkplaceModel?> GetWorkplaceAsync(Guid tenantId, Guid workplaceId, CancellationToken cancellationToken = default)
    {
        var workplace = await _workplaceRepository.GetWorkplaceAsync(workplaceId, cancellationToken);

        if (workplace == null || workplace.TenantId != tenantId)
        {
            return null;
        }

        return new WorkplaceModel
        {
            Id = workplace.Id,
            TenantId = workplace.TenantId,
            Enabled = workplace.Enabled,
            Name = workplace.Name,
            CreatedAt = workplace.CreatedAt,
            UpdatedAt = workplace.UpdatedAt
        };
    }

    /// <inheritdoc />
    public async Task<WorkplaceModel> CreateWorkplaceAsync(Guid tenantId, CreateWorkplaceModel createWorkplaceModel, CancellationToken cancellationToken = default)
    {
        var workplace = new Workplace
        {
            TenantId = tenantId,
            Enabled = createWorkplaceModel.Enabled,
            Name = createWorkplaceModel.Name,
        };

        await _workplaceRepository.AddWorkplaceAsync(workplace, cancellationToken);

        return new WorkplaceModel
        {
            Id = workplace.Id,
            TenantId = workplace.TenantId,
            Enabled = workplace.Enabled,
            Name = workplace.Name,
            CreatedAt = workplace.CreatedAt,
            UpdatedAt = workplace.UpdatedAt
        };
    }

    /// <inheritdoc />
    public async Task UpdateWorkplaceAsync(Guid tenantId, Guid workplaceId, UpdateWorkplaceModel updateWorkplaceModel,
        CancellationToken cancellationToken = default)
    {
        var workplace = await _workplaceRepository.GetWorkplaceAsync(workplaceId, cancellationToken);

        if (workplace == null || workplace.TenantId != tenantId)
        {
            throw new InvalidOperationException($"Workplace with unique identifier {workplaceId} not found.");
        }

        workplace.Enabled = updateWorkplaceModel.Enabled ?? workplace.Enabled;
        workplace.Name = updateWorkplaceModel.Name ?? workplace.Name;

        await _workplaceRepository.UpdateWorkplaceAsync(workplace, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> DeleteWorkplaceAsync(Guid tenantId, Guid workplaceId, CancellationToken cancellationToken = default)
    {
        var workplace = await _workplaceRepository.GetWorkplaceAsync(workplaceId, cancellationToken);

        if (workplace == null || workplace.TenantId != tenantId)
        {
            throw new InvalidOperationException($"Workplace with unique identifier {workplaceId} not found.");
        }

        return await _workplaceRepository.DeleteWorkplaceAsync(workplace.Id, cancellationToken);
    }
}
