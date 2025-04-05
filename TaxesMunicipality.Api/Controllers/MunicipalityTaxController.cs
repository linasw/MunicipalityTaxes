using Microsoft.AspNetCore.Mvc;
using TaxesMunicipality.Core.DTOs;

namespace TaxesMunicipality.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MunicipalityTaxController : ControllerBase
{
    public MunicipalityTaxController()
    {

    }

    [HttpGet]
    public IActionResult GetTax([FromQuery] GetTaxRequest request)
    {
        return Ok();
    }
}

