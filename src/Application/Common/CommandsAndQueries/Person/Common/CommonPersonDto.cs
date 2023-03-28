using AutoMapper;
using ApiTrottling.Application.Common.Mappings;

namespace ApiTrottling.Application.Common.CommandsAndQueries.Person.Common;

public class CommonPersonDto : IMapFrom<Domain.Entities.EF.PrefDbLoginPerson>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? MoveDate { get; set; }
    public string? AddressFromStreet { get; set; }
    public string? AddressFromPostCode { get; set; }
    public string? AddressFromCity { get; set; }
    public string? AddressToStreet { get; set; }
    public string? AddressToPostCode { get; set; }
    public string? AddressToCity { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CommonPersonDto, Domain.Entities.EF.PrefDbLoginPerson>().ReverseMap();
    }
}