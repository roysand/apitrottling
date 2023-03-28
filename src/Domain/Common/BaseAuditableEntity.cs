namespace ApiTrottling.Domain.Common;

public abstract class BaseAuditableEntity
{
    public DateTime? LastModified { get; set; }

}
