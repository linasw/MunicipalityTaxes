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
}

