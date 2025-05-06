using System.ComponentModel.DataAnnotations.Schema;

namespace Medusa.Domain.Tenants;

[Table("tenants", Schema = "public")]
public class Tenant : IAuditable, IIdentifiable
{
    /// <summary>
    ///     The unique identifier for the tenant.
    /// </summary>
    [Column("tenant_id")]
    public required Guid Id { get; init; }

    /// <summary>
    ///     The country code where the tenant is located.
    /// </summary>
    [Column("tenant_country")]
    public required string Country { get; set; }

    /// <summary>
    ///     The name of the tenant.
    /// </summary>
    [Column("tenant_name")]
    public required string Name { get; set; }

    /// <summary>
    ///     The date and time when the tenant was created.
    /// </summary>
    [Column("tenant_created_at")]
    public required DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    ///     The date and time when the tenant was last updated.
    /// </summary>
    [Column("tenant_updated_at")]
    public required DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
