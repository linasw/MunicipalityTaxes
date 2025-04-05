using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxesMunicipality.Core.DTOs;

namespace TaxesMunicipality.Core.Services
{
    public class MunicipalityTaxService : IMunicipalityTaxService
    {
        public GetTaxResponse GetTaxRate(string municipality, DateTime date)
        {
            var model = new GetTaxResponse { Municipality = municipality, TaxRate = 0.01 };

            return model;
        }
    }
}
