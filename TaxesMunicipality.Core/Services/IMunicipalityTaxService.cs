using TaxesMunicipality.Core.DTOs;

namespace TaxesMunicipality.Core.Services
{
    public interface IMunicipalityTaxService
    {
        GetTaxResponse GetTaxRate(string municipality, DateTime date);
    }
}
