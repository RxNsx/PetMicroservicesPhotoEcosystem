namespace Shared;

public sealed record Error(string Code, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "Value cannot be null");
    public static readonly Error LengthExceeded = new("Error.LengthExceeded", "Value length exceeded");
    
    public Result ToResult() => Result.Failure(this);
}