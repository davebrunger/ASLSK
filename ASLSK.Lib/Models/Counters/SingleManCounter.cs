namespace ASLSK.Lib.Models.Counters;

public class SingleManCounter : OneOfBase<GoodOrderSingleManCounter, BrokenSingleManCounter>
{
    protected SingleManCounter(OneOf<GoodOrderSingleManCounter, BrokenSingleManCounter> input) : base(input)
    {
    }

    public static implicit operator SingleManCounter(GoodOrderSingleManCounter goodOrderSingleManCounter) => new(goodOrderSingleManCounter);
    public static implicit operator SingleManCounter(BrokenSingleManCounter brokenSingleManCounter) => new(brokenSingleManCounter);

    public ImmutableHashSet<InformationalMarker> InformationalMarkers => Match(
        goodOrderSingleManCounter => goodOrderSingleManCounter.InformationalMarkers,
        brokenSingleManCounter => brokenSingleManCounter.InformationalMarkers
    );
}
