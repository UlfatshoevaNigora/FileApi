using FilesAPI.Data;
using FilesAPI.Models.Dtos;
using FilesAPI.Models.Entities;
using FilesAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilesAPI.Services.Services;

public class CityService : ICityService
{ private readonly ApplicationDbContext _dbContext;
    public CityService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CityDto> AddCity(CityDto city)
    {
        var c =  new City()
        {
            NameOfCity = city.NameOfCity,
            CountryId = city.CountryId,
        };
        await _dbContext.Cities.AddAsync(c);
        await _dbContext.SaveChangesAsync();
        return city;
    }


    public async Task<bool> DeleteCity(int id)
    {
        var c = await _dbContext.Cities.FindAsync(id);
        _dbContext.Cities.Remove(c);
        var result = await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<City>> GetCitiesAsync()
    {
        var c = await _dbContext.Cities.ToListAsync();
        return c;
    }

    public async Task<City> UpdateCity(City city)
    {
        var find = await _dbContext.Cities.FindAsync(city.Id);
        find.Id = city.Id;
        find.NameOfCity = city.NameOfCity;
        find.CountryId = city.CountryId;
        await _dbContext.SaveChangesAsync();
        return find;
    }

}

