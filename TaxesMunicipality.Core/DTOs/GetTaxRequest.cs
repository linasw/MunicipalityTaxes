﻿namespace TaxesMunicipality.Core.DTOs
{
    public record GetTaxRequest
    {
        public required string Municipality { get; set; }

        public required DateTime Date { get; set; }
    }
}
