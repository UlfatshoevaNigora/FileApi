using FilesAPI.Models.Dtos;
using FilesAPI.Models.Entities;
using FilesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpPost("AddCity")]
    public async Task<ActionResult<CityDto>> Add(CityDto city)
    {
        var c1 = await _cityService.AddCity(city);

        return Ok(c1);
    }

    [HttpPut("UpdateCity")]
    public async Task<ActionResult<City>> Update(City request)
    {
        var city = await _cityService.UpdateCity(request);
        if (city == null) return BadRequest();

        return Ok(city);
    }


    [HttpDelete("DeleteCity")]
    public async Task<ActionResult<bool>> DeleteCity(int id)
    {
        return Ok(await _cityService.DeleteCity(id));
    }


    [HttpGet("GetCities")]
    public async Task<ActionResult<List<City>>> GetListOfCities()
    {
        return Ok(await _cityService.GetCitiesAsync());
    }

}
