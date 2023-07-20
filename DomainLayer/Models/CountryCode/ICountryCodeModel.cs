using DomainLayer.Models.Games;

namespace DomainLayer.Models.CountryCode
{
    public interface ICountryCodeModel
    {
        int CountryCode { get; set; }
        ICollection<IGamesModel> Games { get; set; }
        int Id { get; set; }
        string Name { get; set; }
    }
}