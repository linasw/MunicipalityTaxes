﻿using TaxesMunicipality.Core.DTOs;
using TaxesMunicipality.Core.Enums;
using TaxesMunicipality.Core.Interfaces;

namespace TaxesMunicipality.Core.Services
{
    public class MunicipalityTaxService : IMunicipalityTaxService
    {
        private readonly IMunicipalityTaxRepository _municipalityTaxRepository;

        public MunicipalityTaxService(IMunicipalityTaxRepository municipalityTaxRepository)
        {
            _municipalityTaxRepository = municipalityTaxRepository;
        }

        public GetTaxResponseDTO? GetTaxRate(string municipality, DateTime date)
        {
            try
            {


                var taxes = _municipalityTaxRepository.GetMunicipalityTaxes(municipality, date);

                if (taxes == null)
                {
                    return null;
                }

                var response = new GetTaxResponseDTO
                {
                    Municipality = municipality
                };

                //get the first tax based on priority: Daily > Weekly > Monthly > Yearly
                var dailyTax = taxes.FirstOrDefault(x => x.Type == TaxType.Daily);

                if (dailyTax != null)
                {
                    response.TaxRate = dailyTax.TaxRate;

                    return response;
                }

                var weeklyTax = taxes.FirstOrDefault(x => x.Type == TaxType.Weekly);

                if (weeklyTax != null)
                {
                    response.TaxRate = weeklyTax.TaxRate;

                    return response;
                }

                var monthlyTax = taxes.FirstOrDefault(x => x.Type == TaxType.Monthly);

                if (monthlyTax != null)
                {
                    response.TaxRate = monthlyTax.TaxRate;

                    return response;
                }

                var yearlyTax = taxes.FirstOrDefault(x => x.Type == TaxType.Yearly);

                if (yearlyTax != null)
                {
                    response.TaxRate = yearlyTax.TaxRate;

                    return response;
                }

                return null;
            }
            catch (Exception ex)
            {
                //log the ex
                return null;
            }
        }
    }
}
