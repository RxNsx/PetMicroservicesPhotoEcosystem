namespace Shared;

public static class Ensure
{
    public static void IsNotNull(string value)
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value), "Value cannot be null.");
        }
    }
}