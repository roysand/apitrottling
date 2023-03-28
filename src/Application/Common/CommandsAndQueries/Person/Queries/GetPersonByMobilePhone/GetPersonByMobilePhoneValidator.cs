using FluentValidation;

namespace ApiTrottling.Application.Common.CommandsAndQueries.Person.Queries.GetPersonByMobilePhone;

public class GetPersonByMobilePhoneValidator : AbstractValidator<GetPersonByMobilePhoneQuery>
{
    public GetPersonByMobilePhoneValidator()
    {
        RuleFor(v => v.MobilePhone).MinimumLength(8);
    }
}