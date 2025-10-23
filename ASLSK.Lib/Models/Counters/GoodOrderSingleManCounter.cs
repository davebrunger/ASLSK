namespace ASLSK.Lib.Models.Counters;

public record GoodOrderSingleManCounter
(
    Nationality Nationality,
    int LeadershipModifier,
    PositiveInteger GoodOrderMorale,
    bool ExperienceLevelRatingNotApplicable,
    PositiveInteger BrokenMorale,
    bool SelfRally,
    ImmutableHashSet<InformationalMarker> InformationalMarkers,
    ImmutableList<SupportWeapon> SupportWeapons
)
{
    public static PositiveInteger Size => PositiveInteger.One;
}