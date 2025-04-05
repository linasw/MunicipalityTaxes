using Microsoft.AspNetCore.Mvc;
using TaxesMunicipality.Core.DTOs;
using TaxesMunicipality.Core.Services;

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
    public IActionResult GetTax([FromQuery] GetTaxRequest request)
    {
        var returnModel = _municipalityTaxService.GetTaxRate(request.Municipality, request.Date);

        return Ok(returnModel);
    }
}

