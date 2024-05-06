using FilesAPI.Models.Dtos;
using FilesAPI.Models.Entities;

namespace FilesAPI.Services.Interfaces;

public interface ICountryService
{
    public  Task<CountryDto> AddCountry (CountryDto country);
    public Task<Country> UpdateCountry(Country country);
    public Task<List<Country>>  GetCountriesAsync();
    public Task<bool> DeleteCountry(int id);
}
