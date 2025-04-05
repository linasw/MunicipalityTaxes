namespace TaxesMunicipality.Core.DTOs
{
    public record GetTaxResponseDTO
    {
        public required string Municipality { get; set; }

        public double TaxRate { get; set; }
    }
}
