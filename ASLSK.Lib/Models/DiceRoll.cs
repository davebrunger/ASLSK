namespace ASLSK.Lib.Models;

[BasicWrapper(typeof(int), nameof(Validate))]
public partial class DiceRoll
{
    private static bool Validate(int value)
    {
        return value >= 1 && value <= 6;
    }
}
