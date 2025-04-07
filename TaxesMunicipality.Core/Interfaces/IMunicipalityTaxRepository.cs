using TaxesMunicipality.Core.DTOs;
using TaxesMunicipality.Core.Models;

namespace TaxesMunicipality.Core.Interfaces
{
    public interface IMunicipalityTaxRepository
    {
        IEnumerable<MunicipalityTaxModel> GetMunicipalityTaxes(string municipality, DateTime date);
        Task<bool> AddMunicipalityTaxAsync(MunicipalityTaxModel municipalityTax);
        Task<MunicipalityTaxModel?> GetMunicipalityTaxByIdAsync(int id);
        Task<bool> UpdateMunicipalityTaxAsync(UpdateTaxRequestDTO municipalityTax);
    }
}
