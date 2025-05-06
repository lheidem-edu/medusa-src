using System.ComponentModel.DataAnnotations.Schema;

namespace Medusa.Domain.Workplaces;

[Table("workplaces", Schema = "public")]
public class Workplace : IAuditable, IIdentifiable
{
    /// <summary>
    ///     The unique identifier for the workplace.
    /// </summary>
    [Column("workplace_id")]
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    ///     The unique identifier for the tenant associated with this workplace.
    /// </summary>
    [Column("workplace_tenant_id")]
    public required Guid TenantId { get; set; }

    /// <summary>
    ///     A boolean indicating whether the workplace is enabled or not.
    /// </summary>
    [Column("workplace_enabled")]
    public required bool Enabled { get; set; }

    /// <summary>
    ///     The name of the workplace.
    /// </summary>
    [Column("workplace_name")]
    public required string Name { get; set; }

    /// <summary>
    ///     The date and time when the workplace was created.
    /// </summary>
    [Column("workplace_created_at")]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    ///     The date and time when the workplace was last updated.
    /// </summary>
    [Column("workplace_updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
