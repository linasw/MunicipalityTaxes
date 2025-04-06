using Microsoft.AspNetCore.Mvc;
using TaxesMunicipality.Core.DTOs;
using TaxesMunicipality.Core.Interfaces;

namespace TaxesMunicipality.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MunicipalityTaxController : ControllerBase
{
    private readonly IMunicipalityTaxService _municipalityTaxService;

    public MunicipalityTaxController(IMunicipalityTaxService municipalityTaxService)
    {
        _municipalityTaxService = municipalityTaxService;
    }

    [HttpGet]
    public IActionResult GetTax([FromQuery] GetTaxRequestDTO request)
    {
        var returnModel = _municipalityTaxService.GetTaxRate(request.Municipality, request.Date);

        if (returnModel == null)
        {
            return NotFound();
        }

        return Ok(returnModel);
    }

    [HttpPost]
    public async Task<IActionResult> AddTax(AddTaxRequestDTO request)
    {
        //toDate has to be higher than fromDate
        if (request.FromDate.Date > request.ToDate.Date)
        {
            return BadRequest();
        }

        var result = await _municipalityTaxService.AddTaxRateAsync(request);

        if (!result)
        {
            return BadRequest();
        }

        return Ok();
    }
}

