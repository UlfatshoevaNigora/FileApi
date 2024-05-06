using FilesAPI.Models.Dtos;
using FilesAPI.Models.Entities;

namespace FilesAPI.Services.Interfaces;

public interface ICityService
{
    public Task<CityDto> AddCity (CityDto city);
    public Task<City> UpdateCity(City city);
    public Task<List<City>>   GetCitiesAsync();
    public Task<bool>  DeleteCity(int id);
}
