namespace Medusa.Domain.Devices;

public interface IDeviceActivityRepository
{
    /// <summary>
    ///     Retrieves all device activities.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of <see cref="DeviceActivity" /> objects representing all device activities in the system.</returns>
    Task<IReadOnlyCollection<DeviceActivity>> GetDeviceActivitiesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves all activities for a specific device.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device whose activities to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of <see cref="DeviceActivity" /> objects representing all activities for the specified device.</returns>
    Task<IReadOnlyCollection<DeviceActivity>> GetDeviceActivitiesAsync(Guid deviceId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a device activity by its unique identifier.
    /// </summary>
    /// <param name="deviceActivityId">The unique identifier of the device activity to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="DeviceActivity" /> object representing the device activity with the specified identifier, or null if not found.</returns>
    Task<DeviceActivity?> GetDeviceActivityAsync(Guid deviceActivityId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Adds a new device activity.
    /// </summary>
    /// <param name="deviceActivity">The <see cref="DeviceActivity" /> object representing the activity to add.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The added <see cref="DeviceActivity" /> object.</returns>
    Task<DeviceActivity> AddDeviceActivityAsync(DeviceActivity deviceActivity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing device activity.
    /// </summary>
    /// <param name="deviceActivity">The <see cref="DeviceActivity" /> object representing the device activity to update.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    Task UpdateDeviceAsync(DeviceActivity deviceActivity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a device activity by its unique identifier.
    /// </summary>
    /// <param name="deviceActivityId">The unique identifier of the device activity to delete.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    Task<bool> DeleteDeviceAsync(Guid deviceActivityId, CancellationToken cancellationToken = default);
}
