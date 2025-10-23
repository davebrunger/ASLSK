namespace ASLSK.Lib.Models.Counters;

public record BrokenMultiManCounter
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
