using TaxesMunicipality.Core.Enums;
using TaxesMunicipality.Core.Interfaces;
using TaxesMunicipality.Core.Models;

namespace TaxesMunicipality.Data.Repositories
{
    public class MunicipalityTaxRepository : IMunicipalityTaxRepository
    {
        public IEnumerable<MunicipalityTaxModel> GetMunicipalityTaxes(string municipality, DateTime date)
        {
            //temp
            var taxes = new List<MunicipalityTaxModel>
            {
                new MunicipalityTaxModel
                {
                    Id = 1,
                    Municipality = "Copenhagen",
                    TaxRate = 0.2,
                    Type = TaxType.Yearly,
                    FromDate = new DateTime(2024, 1, 1),
                    ToDate = new DateTime(2024, 12, 31)
                },
                new MunicipalityTaxModel
                {
                    Id = 2,
                    Municipality = "Copenhagen",
                    TaxRate = 0.4,
                    Type = TaxType.Monthly,
                    FromDate = new DateTime(2024, 5, 1),
                    ToDate = new DateTime(2024, 5, 31)
                },
                new MunicipalityTaxModel
                {
                    Id = 3,
                    Municipality = "Copenhagen",
                    TaxRate = 0.1,
                    Type = TaxType.Daily,
                    FromDate = new DateTime(2024, 1, 1),
                    ToDate = new DateTime(2024, 1, 1)
                },
                new MunicipalityTaxModel
                {
                    Id = 4,
                    Municipality = "Copenhagen",
                    TaxRate = 0.1,
                    Type = TaxType.Daily,
                    FromDate = new DateTime(2024, 12, 25),
                    ToDate = new DateTime(2024, 12, 5)      
                }
            };

            //ignore case for municipalities
            var toReturn = taxes
                .Where(x => x.Municipality.Equals(municipality, StringComparison.CurrentCultureIgnoreCase))
                .Where(x => x.FromDate <= date && x.ToDate >= date);

            return toReturn;
        }
    }
}
