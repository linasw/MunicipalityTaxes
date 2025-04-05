using TaxesMunicipality.Core.DTOs;
using TaxesMunicipality.Core.Interfaces;

namespace TaxesMunicipality.Core.Services
{
    public class MunicipalityTaxService : IMunicipalityTaxService
    {
        public GetTaxResponseDTO GetTaxRate(string municipality, DateTime date)
        {
            var model = new GetTaxResponseDTO { Municipality = municipality, TaxRate = 0.01 };

            return model;
        }
    }
}
