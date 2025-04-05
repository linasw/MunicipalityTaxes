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
        var returnModel = new GetTaxResponse
        {
            Municipality = request.Municipality,
            TaxRate = 0.01
        };

        return Ok(returnModel);
    }
}

