namespace ASLSK.Lib.Tables;

[Option("KilledInAction", OfType = typeof(int))]
[Option("Killed", OfType = typeof(int))]
[Option("MoraleCheck", OfType = typeof(int))]
[Option("NormalMoraleCheck")]
[Option("PinTaskCheck")]
public partial class InfantryFireTableResult
{
    public static implicit operator Option<InfantryFireTableResult>(InfantryFireTableResult infantryFireTableResult) =>
        Option.Some(infantryFireTableResult);
}

public static class InfantryFireTable
{
    public static Option<InfantryFireTableResult> GetResult(PositiveInteger firepower, int modifiedDiceRoll)
    {
        return firepower.Value switch
        {
            >= 36 => GetFirepower36Result(modifiedDiceRoll),
            >= 30 => GetFirepower30Result(modifiedDiceRoll),
            >= 24 => GetFirepower24Result(modifiedDiceRoll),
            >= 20 => GetFirepower20Result(modifiedDiceRoll),
            >= 16 => GetFirepower16Result(modifiedDiceRoll),
            >= 12 => GetFirepower12Result(modifiedDiceRoll),
            >= 8 => GetFirepower8Result(modifiedDiceRoll),
            >= 6 => GetFirepower6Result(modifiedDiceRoll),
            >= 4 => GetFirepower4Result(modifiedDiceRoll),
            >= 2 => GetFirepower2Result(modifiedDiceRoll),
            _ => GetFirepower1Result(modifiedDiceRoll)
        };
    }

    private static Option<InfantryFireTableResult> GetFirepower36Result(int modifiedDiceRoll)
    {
        return modifiedDiceRoll switch
        {
            <= 0 => InfantryFireTableResult.KilledInAction(7),
            1 => InfantryFireTableResult.KilledInAction(6),
            2 => InfantryFireTableResult.KilledInAction(5),
            3 => InfantryFireTableResult.KilledInAction(4),
            4 => InfantryFireTableResult.KilledInAction(3),
            5 => InfantryFireTableResult.KilledInAction(2),
            6 => InfantryFireTableResult.KilledInAction(1),
            7 => InfantryFireTableResult.Killed(4),
            8 => InfantryFireTableResult.MoraleCheck(4),
            9 => InfantryFireTableResult.MoraleCheck(3),
            10 => InfantryFireTableResult.MoraleCheck(2),
            11 => InfantryFireTableResult.MoraleCheck(2),
            12 => InfantryFireTableResult.MoraleCheck(1),
            13 => InfantryFireTableResult.MoraleCheck(1),
            14 => InfantryFireTableResult.NormalMoraleCheck,
            >= 15 => InfantryFireTableResult.PinTaskCheck
        };
    }

    private static Option<InfantryFireTableResult> GetFirepower30Result(int modifiedDiceRoll)
    {
        return modifiedDiceRoll switch
        {
            <= 0 => InfantryFireTableResult.KilledInAction(6),
            1 => InfantryFireTableResult.KilledInAction(5),
            2 => InfantryFireTableResult.KilledInAction(4),
            3 => InfantryFireTableResult.KilledInAction(3),
            4 => InfantryFireTableResult.KilledInAction(2),
            5 => InfantryFireTableResult.KilledInAction(1),
            6 => InfantryFireTableResult.Killed(4),
            7 => InfantryFireTableResult.MoraleCheck(4),
            8 => InfantryFireTableResult.MoraleCheck(3),
            9 => InfantryFireTableResult.MoraleCheck(2),
            10 => InfantryFireTableResult.MoraleCheck(2),
            11 => InfantryFireTableResult.MoraleCheck(1),
            12 => InfantryFireTableResult.MoraleCheck(1),
            13 => InfantryFireTableResult.NormalMoraleCheck,
            14 => InfantryFireTableResult.PinTaskCheck,
            >= 15 => Option.None
        };
    }

    private static Option<InfantryFireTableResult> GetFirepower24Result(int modifiedDiceRoll)
    {
        return modifiedDiceRoll switch
        {
            <= 0 => InfantryFireTableResult.KilledInAction(5),
            1 => InfantryFireTableResult.KilledInAction(4),
            2 => InfantryFireTableResult.KilledInAction(3),
            3 => InfantryFireTableResult.KilledInAction(2),
            4 => InfantryFireTableResult.KilledInAction(1),
            5 => InfantryFireTableResult.Killed(4),
            6 => InfantryFireTableResult.MoraleCheck(4),
            7 => InfantryFireTableResult.MoraleCheck(3),
            8 => InfantryFireTableResult.MoraleCheck(2),
            9 => InfantryFireTableResult.MoraleCheck(2),
            10 => InfantryFireTableResult.MoraleCheck(1),
            11 => InfantryFireTableResult.MoraleCheck(1),
            12 => InfantryFireTableResult.NormalMoraleCheck,
            13 => InfantryFireTableResult.PinTaskCheck,
            >= 14 => Option.None
        };
    }

    private static Option<InfantryFireTableResult> GetFirepower20Result(int modifiedDiceRoll)
    {
        return modifiedDiceRoll switch
        {
            <= 0 => InfantryFireTableResult.KilledInAction(4),
            1 => InfantryFireTableResult.KilledInAction(3),
            2 => InfantryFireTableResult.KilledInAction(2),
            3 => InfantryFireTableResult.KilledInAction(1),
            4 => InfantryFireTableResult.Killed(4),
            5 => InfantryFireTableResult.MoraleCheck(4),
            6 => InfantryFireTableResult.MoraleCheck(3),
            7 => InfantryFireTableResult.MoraleCheck(2),
            8 => InfantryFireTableResult.MoraleCheck(2),
            9 => InfantryFireTableResult.MoraleCheck(1),
            10 => InfantryFireTableResult.MoraleCheck(1),
            11 => InfantryFireTableResult.NormalMoraleCheck,
            12 => InfantryFireTableResult.PinTaskCheck,
            >= 13 => Option.None
        };
    }

    private static Option<InfantryFireTableResult> GetFirepower16Result(int modifiedDiceRoll)
    {
        return modifiedDiceRoll switch
        {
            <= 0 => InfantryFireTableResult.KilledInAction(4),
            1 => InfantryFireTableResult.KilledInAction(3),
            2 => InfantryFireTableResult.KilledInAction(2),
            3 => InfantryFireTableResult.KilledInAction(1),
            4 => InfantryFireTableResult.Killed(3),
            5 => InfantryFireTableResult.MoraleCheck(3),
            6 => InfantryFireTableResult.MoraleCheck(2),
            7 => InfantryFireTableResult.MoraleCheck(2),
            8 => InfantryFireTableResult.MoraleCheck(1),
            9 => InfantryFireTableResult.MoraleCheck(1),
            10 => InfantryFireTableResult.NormalMoraleCheck,
            11 => InfantryFireTableResult.PinTaskCheck,
            >= 12 => Option.None
        };
    }

    private static Option<InfantryFireTableResult> GetFirepower12Result(int modifiedDiceRoll)
    {
        return modifiedDiceRoll switch
        {
            <= 0 => InfantryFireTableResult.KilledInAction(3),
            1 => InfantryFireTableResult.KilledInAction(2),
            2 => InfantryFireTableResult.KilledInAction(1),
            3 => InfantryFireTableResult.Killed(3),
            4 => InfantryFireTableResult.MoraleCheck(3),
            5 => InfantryFireTableResult.MoraleCheck(2),
            6 => InfantryFireTableResult.MoraleCheck(2),
            7 => InfantryFireTableResult.MoraleCheck(1),
            8 => InfantryFireTableResult.MoraleCheck(1),
            9 => InfantryFireTableResult.NormalMoraleCheck,
            10 => InfantryFireTableResult.PinTaskCheck,
            >= 11 => Option.None
        };
    }

    private static Option<InfantryFireTableResult> GetFirepower8Result(int modifiedDiceRoll)
    {
        return modifiedDiceRoll switch
        {
            <= 0 => InfantryFireTableResult.KilledInAction(3),
            1 => InfantryFireTableResult.KilledInAction(2),
            2 => InfantryFireTableResult.KilledInAction(1),
            3 => InfantryFireTableResult.Killed(2),
            4 => InfantryFireTableResult.MoraleCheck(2),
            5 => InfantryFireTableResult.MoraleCheck(2),
            6 => InfantryFireTableResult.MoraleCheck(1),
            7 => InfantryFireTableResult.MoraleCheck(1),
            8 => InfantryFireTableResult.NormalMoraleCheck,
            9 => InfantryFireTableResult.PinTaskCheck,
            >= 10 => Option.None
        };
    }

    private static Option<InfantryFireTableResult> GetFirepower6Result(int modifiedDiceRoll)
    {
        return modifiedDiceRoll switch
        {
            <= 0 => InfantryFireTableResult.KilledInAction(3),
            1 => InfantryFireTableResult.KilledInAction(2),
            2 => InfantryFireTableResult.KilledInAction(1),
            3 => InfantryFireTableResult.Killed(2),
            4 => InfantryFireTableResult.MoraleCheck(2),
            5 => InfantryFireTableResult.MoraleCheck(1),
            6 => InfantryFireTableResult.MoraleCheck(1),
            7 => InfantryFireTableResult.NormalMoraleCheck,
            8 => InfantryFireTableResult.PinTaskCheck,
            >= 9 => Option.None
        };
    }

    private static Option<InfantryFireTableResult> GetFirepower4Result(int modifiedDiceRoll)
    {
        return modifiedDiceRoll switch
        {
            <= 0 => InfantryFireTableResult.KilledInAction(2),
            1 => InfantryFireTableResult.KilledInAction(1),
            2 => InfantryFireTableResult.Killed(2),
            3 => InfantryFireTableResult.MoraleCheck(2),
            4 => InfantryFireTableResult.MoraleCheck(1),
            5 => InfantryFireTableResult.MoraleCheck(1),
            6 => InfantryFireTableResult.NormalMoraleCheck,
            7 => InfantryFireTableResult.PinTaskCheck,
            >= 8 => Option.None
        };
    }

    private static Option<InfantryFireTableResult> GetFirepower2Result(int modifiedDiceRoll)
    {
        return modifiedDiceRoll switch
        {
            <= 0 => InfantryFireTableResult.KilledInAction(2),
            1 => InfantryFireTableResult.KilledInAction(1),
            2 => InfantryFireTableResult.Killed(1),
            3 => InfantryFireTableResult.MoraleCheck(1),
            4 => InfantryFireTableResult.MoraleCheck(1),
            5 => InfantryFireTableResult.NormalMoraleCheck,
            6 => InfantryFireTableResult.PinTaskCheck,
            >= 7 => Option.None
        };
    }

    private static Option<InfantryFireTableResult> GetFirepower1Result(int modifiedDiceRoll)
    {
        return modifiedDiceRoll switch
        {
            <= 0 => InfantryFireTableResult.KilledInAction(1),
            1 => InfantryFireTableResult.Killed(1),
            2 => InfantryFireTableResult.MoraleCheck(1),
            3 => InfantryFireTableResult.MoraleCheck(1),
            4 => InfantryFireTableResult.NormalMoraleCheck,
            5 => InfantryFireTableResult.PinTaskCheck,
            >= 6 => Option.None
        };
    }
}
