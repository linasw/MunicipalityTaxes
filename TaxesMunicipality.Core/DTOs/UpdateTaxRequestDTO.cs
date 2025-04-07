using TaxesMunicipality.Core.Enums;

namespace TaxesMunicipality.Core.DTOs
{
    public class UpdateTaxRequestDTO
    {
        public required int Id { get; set; }

        public required string Municipality { get; set; }

        public required TaxType TaxType { get; set; }

        public required double TaxRate { get; set; }

        public required DateTime FromDate { get; set; }

        public required DateTime ToDate { get; set; }
    }
}
