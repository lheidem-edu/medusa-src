using Medusa.Domain.Devices;
using Medusa.Presentation.Devices;

namespace Medusa.Application.Devices;

public class DeviceFacade : IDeviceFacade
{
    private readonly IDeviceRepository _deviceRepository;

    public DeviceFacade(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<DeviceModel>> GetDevicesAsync(Guid tenantId, CancellationToken cancellationToken = default)
    {
        var devices = await _deviceRepository.GetDevicesAsync(tenantId, cancellationToken);

        return devices.Select(d => new DeviceModel
        {
            Id = d.Id,
            TenantId = d.TenantId,
            SerialNumber = d.SerialNumber,
            Name = d.Name,
            Description = d.Description,
            Location = d.Location,
            CreatedAt = d.CreatedAt,
            UpdatedAt = d.UpdatedAt
        }).ToList();
    }

    /// <inheritdoc />
    public async Task<DeviceModel> GetDeviceAsync(Guid tenantId, Guid deviceId, CancellationToken cancellationToken = default)
    {
        var device = await _deviceRepository.GetDeviceAsync(deviceId, cancellationToken);

        if (device == null || device.TenantId != tenantId)
        {
            throw new KeyNotFoundException($"Device with unique identifier {deviceId} not found.");
        }

        return new DeviceModel
        {
            Id = device.Id,
            TenantId = device.TenantId,
            SerialNumber = device.SerialNumber,
            Name = device.Name,
            Description = device.Description,
            Location = device.Location,
            CreatedAt = device.CreatedAt,
            UpdatedAt = device.UpdatedAt
        };
    }

    /// <inheritdoc />
    public async Task<DeviceModel> CreateDeviceAsync(Guid tenantId, CreateDeviceModel model, CancellationToken cancellationToken = default)
    {
        var existingDevice = await _deviceRepository.GetDeviceBySerialNumberAsync(model.SerialNumber, cancellationToken);

        if (existingDevice != null)
        {
            throw new InvalidOperationException($"Device with serial number {model.SerialNumber} already exists.");
        }

        var device = new Device
        {
            TenantId = tenantId,
            SerialNumber = model.SerialNumber,
            Name = model.Name,
            Description = model.Description,
            Location = model.Location
        };

        await _deviceRepository.AddDeviceAsync(device, cancellationToken);

        return new DeviceModel
        {
            Id = device.Id,
            TenantId = device.TenantId,
            SerialNumber = device.SerialNumber,
            Name = device.Name,
            Description = device.Description,
            Location = device.Location,
            CreatedAt = device.CreatedAt,
            UpdatedAt = device.UpdatedAt
        };
    }

    /// <inheritdoc />
    public async Task UpdateDeviceAsync(Guid tenantId, Guid deviceId, UpdateDeviceModel model,
        CancellationToken cancellationToken = default)
    {
        var device = await _deviceRepository.GetDeviceAsync(deviceId, cancellationToken);

        if (device == null || device.TenantId != tenantId)
        {
            throw new KeyNotFoundException($"Device with unique identifier {deviceId} not found.");
        }

        if (!string.IsNullOrWhiteSpace(model.SerialNumber))
        {
            var existingDevice = await _deviceRepository.GetDeviceBySerialNumberAsync(model.SerialNumber, cancellationToken);

            if (existingDevice != null && existingDevice.Id != deviceId)
            {
                throw new InvalidOperationException($"Device with serial number {model.SerialNumber} already exists.");
            }

            device.SerialNumber = model.SerialNumber;
        }

        device.Name = model.Name ?? device.Name;
        device.Description = model.Description ?? device.Description;
        device.Location = model.Location ?? device.Location;

        device.UpdatedAt = DateTime.UtcNow;

        await _deviceRepository.UpdateDeviceAsync(device, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> DeleteDeviceAsync(Guid tenantId, Guid deviceId, CancellationToken cancellationToken = default)
    {
        var device = await _deviceRepository.GetDeviceAsync(deviceId, cancellationToken);

        if (device == null || device.TenantId != tenantId)
        {
            throw new KeyNotFoundException($"Device with unique identifier {deviceId} not found.");
        }

        var result = await _deviceRepository.DeleteDeviceAsync(device.Id, cancellationToken);
        return result;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<DeviceActivityModel>> GetDeviceActivitiesAsync(Guid tenantId, Guid deviceId, CancellationToken cancellationToken = default)
    {
        var device = await _deviceRepository.GetDeviceAsync(deviceId, cancellationToken);

        if (device == null || device.TenantId != tenantId)
        {
            throw new KeyNotFoundException($"Device with unique identifier {deviceId} not found.");
        }

        var activities = await _deviceRepository.GetDeviceActivitiesAsync(deviceId, cancellationToken);

        return activities.Select(da => new DeviceActivityModel
        {
            Id = da.Id,
            DeviceId = da.DeviceId,
            Type = da.Type,
            CreatedAt = da.CreatedAt,
            UpdatedAt = da.UpdatedAt
        }).ToList();
    }

    /// <inheritdoc />
    public async Task<DeviceActivityModel> GetDeviceActivityAsync(Guid tenantId, Guid deviceId, Guid activityId,
        CancellationToken cancellationToken = default)
    {
        var device = await _deviceRepository.GetDeviceAsync(deviceId, cancellationToken);

        if (device == null || device.TenantId != tenantId)
        {
            throw new KeyNotFoundException($"Device with unique identifier {deviceId} not found.");
        }

        var activity = await _deviceRepository.GetDeviceActivityAsync(activityId, cancellationToken);

        if (activity == null || activity.DeviceId != deviceId)
        {
            throw new KeyNotFoundException($"Device activity with unique identifier {activityId} not found.");
        }

        return new DeviceActivityModel
        {
            Id = activity.Id,
            DeviceId = activity.DeviceId,
            Type = activity.Type,
            CreatedAt = activity.CreatedAt,
            UpdatedAt = activity.UpdatedAt
        };
    }

    /// <inheritdoc />
    public async Task<DeviceActivityModel> CreateDeviceActivityAsync(Guid tenantId, Guid deviceId, CreateDeviceActivityModel model,
        CancellationToken cancellationToken = default)
    {
        var device = await _deviceRepository.GetDeviceAsync(deviceId, cancellationToken);

        if (device == null || device.TenantId != tenantId)
        {
            throw new KeyNotFoundException($"Device with unique identifier {deviceId} not found.");
        }

        var activity = new DeviceActivity
        {
            DeviceId = deviceId,
            Type = model.Type
        };

        await _deviceRepository.AddDeviceActivityAsync(activity, cancellationToken);

        return new DeviceActivityModel
        {
            Id = activity.Id,
            DeviceId = activity.DeviceId,
            Type = activity.Type,
            CreatedAt = activity.CreatedAt,
            UpdatedAt = activity.UpdatedAt
        };
    }

    /// <inheritdoc />
    public async Task<bool> DeleteDeviceActivityAsync(Guid tenantId, Guid deviceId, Guid activityId,
        CancellationToken cancellationToken = default)
    {
        var device = await _deviceRepository.GetDeviceAsync(deviceId, cancellationToken);

        if (device == null || device.TenantId != tenantId)
        {
            throw new KeyNotFoundException($"Device with unique identifier {deviceId} not found.");
        }

        var activity = await _deviceRepository.GetDeviceActivityAsync(activityId, cancellationToken);

        if (activity == null || activity.DeviceId != deviceId)
        {
            throw new KeyNotFoundException($"Device activity with unique identifier {activityId} not found.");
        }

        return await _deviceRepository.DeleteDeviceActivityAsync(activity.Id, cancellationToken);
    }
}
