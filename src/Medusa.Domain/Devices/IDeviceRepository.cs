namespace Medusa.Domain.Devices;

public interface IDeviceRepository
{
    /// <summary>
    ///     Retrieves all devices.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of <see cref="Device" /> objects representing all devices in the system.</returns>
    Task<IReadOnlyCollection<Device>> GetDevicesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves all devices associated with a specific tenant.
    /// </summary>
    /// <param name="tenantId">The unique identifier of the tenant whose devices to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of <see cref="Device" /> objects representing all devices associated with the specified tenant.</returns>
    Task<IReadOnlyCollection<Device>> GetDevicesAsync(Guid tenantId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a device by its unique identifier.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Device" /> object representing the device with the specified identifier, or null if not found.</returns>
    Task<Device?> GetDeviceAsync(Guid deviceId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Adds a new device.
    /// </summary>
    /// <param name="device">The <see cref="Device" /> object representing the device to add.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The added <see cref="Device" /> object.</returns>
    Task<Device> AddDeviceAsync(Device device, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing device.
    /// </summary>
    /// <param name="device">The <see cref="Device" /> object representing the device to update.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    Task UpdateDeviceAsync(Device device, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a device by its unique identifier.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device to delete.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    Task<bool> DeleteDeviceAsync(Guid deviceId, CancellationToken cancellationToken = default);
}
