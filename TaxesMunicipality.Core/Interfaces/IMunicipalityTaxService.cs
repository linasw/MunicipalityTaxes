using TaxesMunicipality.Core.DTOs;

namespace TaxesMunicipality.Core.Interfaces
{
    public interface IMunicipalityTaxService
    {
        GetTaxResponseDTO? GetTaxRate(string municipality, DateTime date);

        Task<bool> AddTaxRateAsync(AddTaxRequestDTO addTaxRequestDTO);

        Task<bool> UpdateTaxRateAsync(UpdateTaxRequestDTO updateTaxRequestDTO);
    }
}
