namespace TaxesMunicipality.Core.DTOs
{
    public record GetTaxResponse
    {
        public required string Municipality { get; set; }

        public double TaxRate { get; set; }
    }
}
