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

        public IEnumerable<MunicipalityTaxModel> GetMunicipalityTaxes(string municipality, DateTime date)
        {
            //ignore case for municipalities
            var toReturn = _context.MunicipalityTaxes
                .Where(x => x.Municipality.ToLower() == municipality.ToLower())
                .Where(x => x.FromDate <= date && x.ToDate >= date);

            return toReturn;
        }
    }
}
