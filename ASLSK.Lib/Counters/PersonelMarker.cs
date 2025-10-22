namespace ASLSK.Lib.Counters;

[Option("GoodOrder")]
[Option("Broken")]
public partial class PersonelMarkerSide
{
}

public interface IPersonelMarker
{
    PersonelMarkerSide FaceUpSide { get; }
    int GoodOrderMorale { get; }
    bool ExperienceLevelRatingNotApplicable { get; }
    bool BrokenMorale { get; }
    bool SelfRally { get; }
}

public class PersonelMarker : OneOfBase<SingleManCounter, MultiManCounter>, IPersonelMarker
{
    protected PersonelMarker(OneOf<SingleManCounter, MultiManCounter> input) : base(input)
    {
    }

    public static implicit operator PersonelMarker(SingleManCounter singleManCounter) => new(singleManCounter);
    public static implicit operator PersonelMarker(MultiManCounter multiManCounter) => new(multiManCounter);

    public int GoodOrderMorale => Match(
        singleMan => singleMan.GoodOrderMorale,
        multiMan => multiMan.GoodOrderMorale
    );

    public bool ExperienceLevelRatingNotApplicable => Match(
        singleMan => singleMan.ExperienceLevelRatingNotApplicable,
        multiMan => multiMan.ExperienceLevelRatingNotApplicable
    );

    public bool BrokenMorale => Match(
        singleMan => singleMan.BrokenMorale,
        multiMan => multiMan.BrokenMorale
    );

    public bool SelfRally => Match(
        singleMan => singleMan.SelfRally,
        multiMan => multiMan.SelfRally
    );

    public PersonelMarkerSide FaceUpSide => Match(
        singleMan => singleMan.FaceUpSide,
        multiMan => multiMan.FaceUpSide
    );
}
