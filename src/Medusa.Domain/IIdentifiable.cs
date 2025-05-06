namespace Medusa.Domain;

public interface IIdentifiable
{
    /// <summary>
    ///     The unique identifier for the entity.
    /// </summary>
    /// <remarks>
    ///     This property is typically used to uniquely identify the entity within a database or application context.
    /// </remarks>
    Guid Id { get; init; }
}
