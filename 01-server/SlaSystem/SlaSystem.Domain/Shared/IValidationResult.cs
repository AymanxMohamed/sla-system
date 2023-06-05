namespace SlaSystem.Domain.Shared;
public interface IValidationResult
{
    protected static readonly Error ValidationError = new("ValidationError", "");
}