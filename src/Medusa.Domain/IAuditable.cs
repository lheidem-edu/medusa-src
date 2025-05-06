namespace Medusa.Domain;

public interface IAuditable
{
    /// <summary>
    ///     The date and time when the entity was created.
    /// </summary>
    /// <remarks>
    ///     This property is typically set when the entity is first created and should not be modified afterwards.
    /// </remarks>
    DateTime CreatedAt { get; init; }

    /// <summary>
    ///     The date and time when the entity was last updated.
    /// </summary>
    /// <remarks>
    ///     This property is typically updated whenever the entity is modified.
    /// </remarks>
    DateTime UpdatedAt { get; set; }
}