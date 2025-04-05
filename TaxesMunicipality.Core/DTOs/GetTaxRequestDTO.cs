namespace TaxesMunicipality.Core.DTOs
{
    public record GetTaxRequestDTO
    {
        public required string Municipality { get; set; }

        public required DateTime Date { get; set; }
    }
}
