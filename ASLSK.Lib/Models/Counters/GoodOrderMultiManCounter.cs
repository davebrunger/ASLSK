namespace ASLSK.Lib.Models.Counters;

[Option("Squad")]
[Option("HalfSquad")]
public partial class MultiManCounterType
{
}

[Option("Elite")]
[Option("FirstLine")]
[Option("SecondLine")]
[Option("Green")]
[Option("Conscript")]
public partial class MultiManCounterClass
{
    public static ImmutableHashSet<MultiManCounterClass> ExperiencedClasses { get; } = [Elite, FirstLine, SecondLine];
}

public abstract record GoodOrderMultiManCounter
(
    Nationality Nationality,
    MultiManCounterType Type,
    PositiveInteger Firepower,
    bool AssaultFire,
    PositiveInteger? SmokeExponent,
    PositiveInteger NormalRange,
    MultiManCounterClass Class,
    PositiveInteger GoodOrderMorale,
    bool ExperienceLevelRatingNotApplicable,
    PositiveInteger BrokenMorale,
    bool SelfRally,
    ImmutableHashSet<InformationalMarker> InformationalMarkers,
    ImmutableList<SupportWeapon> SupportWeapons
)
{
    public bool Experienced => MultiManCounterClass.ExperiencedClasses.Contains(Class);

    public PositiveInteger Size => Type.Match(() => PositiveInteger.Ten, () => PositiveInteger.Five);
}
