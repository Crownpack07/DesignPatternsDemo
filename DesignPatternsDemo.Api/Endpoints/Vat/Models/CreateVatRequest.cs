namespace DesignPatternsDemo.Api.Endpoints.Vat.Models;

public record CreateVatRequest(decimal Value, DateTime EffectiveFrom);