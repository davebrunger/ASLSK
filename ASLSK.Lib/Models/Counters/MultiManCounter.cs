namespace ASLSK.Lib.Models.Counters;

public class MultiManCounter : OneOfBase<GoodOrderMultiManCounter, BrokenMultiManCounter>
{
    protected MultiManCounter(OneOf<GoodOrderMultiManCounter, BrokenMultiManCounter> input) : base(input)
    {
    }
 
    public static implicit operator MultiManCounter(GoodOrderMultiManCounter goodOrderMultiManCounter) => new(goodOrderMultiManCounter);
    public static implicit operator MultiManCounter(BrokenMultiManCounter brokenMultiManCounter) => new(brokenMultiManCounter);

    public MultiManCounterClass Class => Match(
        goodOrderMultiManCounter => goodOrderMultiManCounter.Class,
        brokenMultiManCounter => brokenMultiManCounter.Class
    );
}
