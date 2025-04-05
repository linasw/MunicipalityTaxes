using TaxesMunicipality.Core.Enums;

namespace TaxesMunicipality.Core.Models
{
    public class MunicipalityTaxModel
    {
        public int Id { get; set; }
        public required string Municipality { get; set; }
        public double TaxRate { get; set; }
        public TaxType Type { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
