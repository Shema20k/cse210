public class Address
{
    private string _street;
    private string _city;
    private string _district;
    private string _country;

    public Address(string street, string city, string district, string country)
    {
        _street = street;
        _city = city;
        _district = district;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToUpper() == "USA" || _country.ToUpper() == "UNITED STATES";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_district}\n{_country}";
    }
}
