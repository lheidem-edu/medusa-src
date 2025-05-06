using Medusa.Presentation.Devices;

namespace Medusa.Application.Devices;

public interface IDeviceFacade
{
    /// <summary>
    ///     Retrieves all devices.
    /// </summary>
    /// <param name="tenantId">The unique identifier of the tenant whose devices to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of <see cref="DeviceModel" /> objects representing all devices in the system.</returns>
    Task<IReadOnlyCollection<DeviceModel>> GetDevicesAsync(Guid tenantId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a device by its unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier to check the device against.</param>
    /// <param name="deviceId">The unique identifier of the device to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="DeviceModel" /> object representing the device with the specified identifier, or null if not found.</returns>
    Task<DeviceModel?> GetDeviceAsync(Guid tenantId, Guid deviceId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Creates a new device.
    /// </summary>
    /// <param name="tenantId">The unique identifier to check the device against.</param>
    /// <param name="createDeviceModel">The <see cref="CreateDeviceModel" /> object representing the device to create.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The created <see cref="DeviceModel" /> object.</returns>
    Task<DeviceModel> CreateDeviceAsync(Guid tenantId, CreateDeviceModel createDeviceModel, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing device.
    /// </summary>
    /// <param name="tenantId">The unique identifier to check the device against.</param>
    /// <param name="deviceId">The unique identifier of the device to update.</param>
    /// <param name="updateDeviceModel">The <see cref="UpdateDeviceModel" /> object representing the device to update.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    Task UpdateDeviceAsync(Guid tenantId, Guid deviceId, UpdateDeviceModel updateDeviceModel, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a device by its unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier to check the device against.</param>
    /// <param name="deviceId">The unique identifier of the device to delete.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    Task<bool> DeleteDeviceAsync(Guid tenantId, Guid deviceId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves all activities for a specific device.
    /// </summary>
    /// <param name="tenantId">The unique identifier to check the device against.</param>
    /// <param name="deviceId">The unique identifier of the device whose activities to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of <see cref="DeviceActivityModel" /> objects representing all activities for the specified device.</returns>
    Task<IReadOnlyCollection<DeviceActivityModel>> GetDeviceActivitiesAsync(Guid tenantId, Guid deviceId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a device activity by its unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier to check the device against.</param>
    /// <param name="deviceId">The unique identifier of the device whose activity to retrieve.</param>
    /// <param name="deviceActivityId">The unique identifier of the device activity to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="DeviceActivityModel" /> object representing the device activity with the specified identifier, or null if not found.</returns>
    Task<DeviceActivityModel?> GetDeviceActivityAsync(Guid tenantId, Guid deviceId, Guid deviceActivityId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Creates a new device activity.
    /// </summary>
    /// <param name="tenantId">The unique identifier to check the device against.</param>
    /// <param name="deviceId">The unique identifier of the device for which to create the activity.</param>
    /// <param name="createDeviceActivityModel">The <see cref="CreateDeviceActivityModel" /> object representing the activity to create.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The created <see cref="DeviceActivityModel" /> object.</returns>
    Task<DeviceActivityModel> CreateDeviceActivityAsync(Guid tenantId, Guid deviceId, CreateDeviceActivityModel createDeviceActivityModel, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a device activity by its unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier to check the device against.</param>
    /// <param name="deviceId">The unique identifier of the device whose activity to delete.</param>
    /// <param name="deviceActivityId">The unique identifier of the device activity to delete.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    Task<bool> DeleteDeviceActivityAsync(Guid tenantId, Guid deviceId, Guid deviceActivityId, CancellationToken cancellationToken = default);
}
