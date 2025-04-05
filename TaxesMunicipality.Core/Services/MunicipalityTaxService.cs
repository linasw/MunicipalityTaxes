using TaxesMunicipality.Core.DTOs;
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

            var model = new GetTaxResponseDTO { Municipality = municipality, TaxRate = 0.01 };

            return model;
        }
    }
}
