namespace ASLSK.Lib.Counters;

public enum MultiManCounterType
{
    Squad,
    HalfSquad,
    Crew
}

public enum MultiManCounterClass
{
    Elite,
    FirstLine,
    SecondLine,
    Green,
    Conscript
}

public record MultiManCounter
(
    MultiManCounterType Type,
    int Firepower,
    bool AssaultFire,
    int? SmokeExponent,
    int NormalRange,
    PersonelMarkerSide FaceUpSide,
    int GoodOrderMorale,
    bool ExperienceLevelRatingNotApplicable,
    bool BrokenMorale,
    bool SelfRally
) : IPersonelMarker
{
}
