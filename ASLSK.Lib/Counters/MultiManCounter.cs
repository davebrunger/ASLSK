namespace ASLSK.Lib.Counters;

[Option("Squad")]
[Option("HalfSquad")]
[Option("Crew")]
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
}

public record MultiManCounter
(
    MultiManCounterType Type,
    int Firepower,
    bool AssaultFire,
    int? SmokeExponent,
    int NormalRange,
    MultiManCounterClass Class,
    PersonelMarkerSide FaceUpSide,
    int GoodOrderMorale,
    bool ExperienceLevelRatingNotApplicable,
    bool BrokenMorale,
    bool SelfRally
) : IPersonelMarker
{
}
