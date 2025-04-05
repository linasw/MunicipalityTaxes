using TaxesMunicipality.Core.Models;

namespace TaxesMunicipality.Core.Interfaces
{
    public interface IMunicipalityTaxRepository
    {
        MunicipalityTaxModel GetMunicipalityTax(int municipality, DateTime from, DateTime to);
    }
}
