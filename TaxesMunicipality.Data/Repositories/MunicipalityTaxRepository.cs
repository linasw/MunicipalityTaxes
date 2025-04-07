using Microsoft.EntityFrameworkCore;
using TaxesMunicipality.Core.DTOs;
using TaxesMunicipality.Core.Interfaces;
using TaxesMunicipality.Core.Models;

namespace TaxesMunicipality.Data.Repositories
{
    public class MunicipalityTaxRepository : IMunicipalityTaxRepository
    {
        private readonly TaxesDbContext _context;

        public MunicipalityTaxRepository(TaxesDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMunicipalityTaxAsync(MunicipalityTaxModel municipalityTax)
        {
            try
            {
                await _context.MunicipalityTaxes.AddAsync(municipalityTax);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public async Task<MunicipalityTaxModel?> GetMunicipalityTaxByIdAsync(int id)
        {
            try
            {
                return await _context.MunicipalityTaxes.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<MunicipalityTaxModel> GetMunicipalityTaxes(string municipality, DateTime date)
        {
            //ignore case for municipalities
            var toReturn = _context.MunicipalityTaxes
                .Where(x => x.Municipality.ToLower() == municipality.ToLower())
                .Where(x => x.FromDate <= date && x.ToDate >= date);

            return toReturn;
        }

        public async Task<bool> UpdateMunicipalityTaxAsync(UpdateTaxRequestDTO municipalityTax)
        {
            try
            { 
                await _context.MunicipalityTaxes.Where(x => x.Id == municipalityTax.Id)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(z => z.Municipality, municipalityTax.Municipality)
                        .SetProperty(z => z.TaxRate, municipalityTax.TaxRate)
                        .SetProperty(z => z.Type, municipalityTax.TaxType)
                        .SetProperty(z => z.FromDate, municipalityTax.FromDate)
                        .SetProperty(z => z.ToDate, municipalityTax.ToDate));

                return true;
            }
            catch (Exception ex)
            {
                //log ex
                return false;
            }
        }
    }
}
