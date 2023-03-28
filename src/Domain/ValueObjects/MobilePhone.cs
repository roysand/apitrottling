using ApiTrottling.Domain.Common.Enums;

namespace ApiTrottling.Domain.ValueObjects;

public class MobilePhone : ValueObject
{
        public string MobilePhoneNumber { get; private set; } = string.Empty;
    public string CountryCode { get; private set; } = string.Empty;

    private MobilePhone()
    {
    }
    private MobilePhone(string mobilePhoneNumber, string countryCodeValid)
    {
        MobilePhoneNumber = mobilePhoneNumber;
        CountryCode = string.Empty;
    }

    public static MobilePhone For(string mobilePhoneString, string countryCodeValid)
    {
        var mobilePhone = Validate(mobilePhoneString, countryCodeValid);
        return mobilePhone;
    }

    private static MobilePhone Validate(string mobilePhoneString, string CountryCodeValid)
    {
        bool isValid = true;
        var errorMessage = "Only Norwegian mobile phone numbers are valid [+47]8 digits without space";
        var mobilePhone = new MobilePhone();

        if (mobilePhoneString.Length == (int)ValidPhoneNumberLength.Long)
        {
            if (!mobilePhoneString.StartsWith(CountryCodeValid))
            {
                isValid = false;
            }
        }
        else if (mobilePhoneString.Length == (int)ValidPhoneNumberLength.Medium)
        {
            if (!mobilePhoneString.StartsWith(CountryCodeValid.Substring(1,2)))
            {
                isValid = false;
            }
        }
        else if (mobilePhoneString.Length != (int)ValidPhoneNumberLength.Short)
        {
           isValid = false;
        }

        if (isValid && !mobilePhoneString.Substring(mobilePhoneString.Length - 8).All(char.IsDigit))
        {
            isValid = false;
        }
        
        if (!isValid)
        {
            throw new MobilePhoneInvalidException(mobilePhoneString, errorMessage);
        }

        mobilePhone.MobilePhoneNumber = mobilePhoneString.Substring(mobilePhoneString.Length - 8);
        mobilePhone.CountryCode = CountryCodeValid;

        return mobilePhone;
    }
    
    public static implicit operator string(MobilePhone mobilePhone)
    {
        return mobilePhone.ToString();
    }
    public override string ToString()
    {
        return CountryCode + MobilePhoneNumber;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CountryCode;
        yield return MobilePhoneNumber;
    }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return CountryCode;
        yield return MobilePhoneNumber;
    }
}