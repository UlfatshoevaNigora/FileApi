using FilesAPI.Data;
using FilesAPI.Models.Dtos;
using FilesAPI.Models.Entities;
using FilesAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilesAPI.Services.Services;

public class CountryService: ICountryService
{

    private readonly ApplicationDbContext _dbContext;
    public CountryService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CountryDto> AddCountry(CountryDto country)
    {
        var c = new Country()
        {
            NameOfCountry = country.NameOfCountry,
            Description = country.Description,
        };
        await _dbContext.Countries.AddAsync(c);
        await _dbContext.SaveChangesAsync();
        return country;
    }


    public async Task<bool> DeleteCountry(int id)
    {
        var c = await _dbContext.Countries.FindAsync(id);
        _dbContext.Countries.Remove(c);
        var result = await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Country>> GetCountriesAsync()
    {
        var c = await _dbContext.Countries.Include(x => x.Cities).ToListAsync();
        return c;
    }

    public async Task<Country> UpdateCountry(Country country)
    {
        var find = await _dbContext.Countries.FindAsync(country.id);
        find.id = country.id;
        find.NameOfCountry = country.NameOfCountry;
        find.Description = country.Description;
        await _dbContext.SaveChangesAsync();
        return find;
    }
}
