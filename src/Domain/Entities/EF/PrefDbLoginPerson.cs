namespace ApiTrottling.Domain.Entities.EF;
public class PrefDbLoginPerson : BaseAuditableEntity
{
    public string MobilePhone { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Gender { get; set; }
    public DateTime? MoveDate { get; set; }
    public int? HouseholdCount { get; set; }
    public int? ObjectId { get; set; }
    public bool? EmailConsent { get; set; }
    public bool? DmConsent { get; set; }
    public bool? SmsConsent { get; set; }
    public string? AddressFromStreet { get; set; }
    public string? AddressFromPostCode { get; set; }
    public string? AddressFromCity { get; set; }
    public string? AddressToStreet { get; set; }
    public string? AddressToPostCode { get; set; }
    public string? AddressToCity { get; set; }
    public string? SmsToken { get; set; }
    public DateTime? SmsTokenExpireDate { get; set; }
    public bool? TmReservation { get; set; }
    public string? SessionCookie { get; set; }
    public Guid? SessionId { get; set; }
}