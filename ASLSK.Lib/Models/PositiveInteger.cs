namespace ASLSK.Lib.Models;

[BasicWrapper(typeof(int), nameof(Validate))]
public partial class PositiveInteger
{
    private static bool Validate(int value)
    {
        return value >= 1;
    }

    public static PositiveInteger One { get; } = new PositiveInteger(1);
    public static PositiveInteger Five { get; } = new PositiveInteger(5);
    public static PositiveInteger Ten { get; } = new PositiveInteger(10);
}
