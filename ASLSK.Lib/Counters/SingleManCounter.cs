namespace ASLSK.Lib.Counters;

public record SingleManCounter
(
    int LeadershipModifier,
    PersonelMarkerSide FaceUpSide,
    int GoodOrderMorale,
    bool ExperienceLevelRatingNotApplicable,
    bool BrokenMorale,
    bool SelfRally
) : IPersonelMarker
{
}