using FilesAPI.Models.Dtos;
using FilesAPI.Models.Entities;
using FilesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpPost("AddCountry")]
    public async Task<ActionResult<CountryDto>> Add (CountryDto country)  
    {
        var c1 = await _countryService.AddCountry(country);

        return Ok(c1);
    }

     [HttpPut("Update")]
    public async Task<ActionResult<Country>> Update(Country request)
    {
        var country = await _countryService.UpdateCountry(request);
        if (country == null) return BadRequest();

        return Ok(country);
    }
    

    [HttpDelete("DeleteCountry")]
    public async Task<ActionResult<bool>> DeleteCountry (int id)
    {
        return Ok( await _countryService.DeleteCountry(id));
    }


    [HttpGet("GetCountries")]
    public async Task<IActionResult> GetListOfCountrs()
    {
        return Ok (await _countryService.GetCountriesAsync());
    }

}
