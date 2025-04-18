﻿using Microsoft.AspNetCore.Mvc;
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

        return CreatedAtAction(nameof(GetTax), new { municipality = request.Municipality, rate = request.TaxRate });
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateTax(UpdateTaxRequestDTO request)
    {
        //we don't have a functionality to get all current tax rates, but we need to know the ID to update the tax record...
        //TODO in the future: add endpoint to get all tax records with IDs OR return ID in GetTax

        //toDate has to be higher than fromDate
        if (request.FromDate.Date > request.ToDate.Date)
        {
            return BadRequest();
        }

        var result = await _municipalityTaxService.UpdateTaxRateAsync(request);

        if (!result)
        {
            return BadRequest();
        }

        return NoContent();
    }
}

