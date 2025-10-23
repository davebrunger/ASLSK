namespace ASLSK.Lib.Models.Counters;

public class BrokenPersonnelMarker : OneOfBase<BrokenSingleManCounter, BrokenMultiManCounter>
{
    protected BrokenPersonnelMarker(OneOf<BrokenSingleManCounter, BrokenMultiManCounter> input) : base(input)
    {
    }
    public static implicit operator BrokenPersonnelMarker(BrokenSingleManCounter singleManCounter) => new(singleManCounter);
    public static implicit operator BrokenPersonnelMarker(BrokenMultiManCounter multiManCounter) => new(multiManCounter);
}
