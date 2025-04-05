using TaxesMunicipality.Core.Models;

namespace TaxesMunicipality.Core.Interfaces
{
    public interface IMunicipalityTaxRepository
    {
        IEnumerable<MunicipalityTaxModel> GetMunicipalityTaxes(string municipality, DateTime date);
    }
}
