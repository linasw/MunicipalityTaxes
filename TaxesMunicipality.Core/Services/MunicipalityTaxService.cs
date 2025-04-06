using TaxesMunicipality.Core.DTOs;
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

        public GetTaxResponseDTO GetTaxRate(string municipality, DateTime date)
        {
            var taxes = _municipalityTaxRepository.GetMunicipalityTaxes(municipality, date);

            //get the first tax based on priority: Daily > Weekly > Monthly > Yearly
            var dailyTax = taxes.FirstOrDefault(x => x.Type == TaxType.Daily);

            if (dailyTax != null)
            {
                var response = new GetTaxResponseDTO
                {
                    Municipality = municipality,
                    TaxRate = dailyTax.TaxRate,
                };

                return response;
            }

            var weeklyTax = taxes.FirstOrDefault(x => x.Type == TaxType.Weekly);

            if (weeklyTax != null)
            {
                var response = new GetTaxResponseDTO
                {
                    Municipality = municipality,
                    TaxRate = weeklyTax.TaxRate,
                };

                return response;
            }

            var monthlyTax = taxes.FirstOrDefault(x => x.Type == TaxType.Monthly);

            if (monthlyTax != null)
            {
                var response = new GetTaxResponseDTO
                {
                    Municipality = municipality,
                    TaxRate = monthlyTax.TaxRate,
                };

                return response;
            }

            var yearlyTax = taxes.FirstOrDefault(x => x.Type == TaxType.Yearly);

            if (yearlyTax != null)
            {
                var response = new GetTaxResponseDTO
                {
                    Municipality = municipality,
                    TaxRate = yearlyTax.TaxRate,
                };

                return response;
            }

            return null;
        }
    }
}
