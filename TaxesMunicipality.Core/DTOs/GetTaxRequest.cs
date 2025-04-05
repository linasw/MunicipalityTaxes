namespace TaxesMunicipality.Core.DTOs
{
    public class GetTaxRequest
    {
        public required string Municipality { get; set; }

        public required DateTime Date { get; set; }
    }
}
