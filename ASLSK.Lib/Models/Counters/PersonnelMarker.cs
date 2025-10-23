namespace ASLSK.Lib.Models.Counters;

public class PersonnelMarker : OneOfBase<GoodOrderSingleManCounter, GoodOrderMultiManCounter, BrokenSingleManCounter, BrokenMultiManCounter>
{
    protected PersonnelMarker(OneOf<GoodOrderSingleManCounter, GoodOrderMultiManCounter, BrokenSingleManCounter, BrokenMultiManCounter> input) : base(input)
    {
    }

    public static implicit operator PersonnelMarker(GoodOrderSingleManCounter singleManCounter) => new(singleManCounter);
    public static implicit operator PersonnelMarker(GoodOrderMultiManCounter multiManCounter) => new(multiManCounter);
    public static implicit operator PersonnelMarker(BrokenSingleManCounter brokenSingleManCounter) => new(brokenSingleManCounter);
    public static implicit operator PersonnelMarker(BrokenMultiManCounter brokenMultiManCounter) => new(brokenMultiManCounter);

    public static implicit operator PersonnelMarker(BrokenPersonnelMarker brokenPersonnelMarker) => brokenPersonnelMarker.Match<PersonnelMarker>(
        singleManCounter => singleManCounter,
        multiManCounter => multiManCounter
    );
    
    public static implicit operator PersonnelMarker(GoodOrderPersonnelMarker goodOrderPersonnelMarker) => goodOrderPersonnelMarker.Match<PersonnelMarker>(
        singleManCounter => singleManCounter,
        multiManCounter => multiManCounter
    );

    public static implicit operator PersonnelMarker(SingleManCounter singleManCounter) => singleManCounter.Match<PersonnelMarker>(
        goodOrderCounter => goodOrderCounter,
        brokenCounter => brokenCounter
    );

    public static implicit operator PersonnelMarker(MultiManCounter multiManCounter) => multiManCounter.Match<PersonnelMarker>(
        goodOrderCounter => goodOrderCounter,
        brokenCounter => brokenCounter
    );

    public OneOf<GoodOrderPersonnelMarker, BrokenPersonnelMarker> ToPersonelMarker()
    {
        return Match<OneOf<GoodOrderPersonnelMarker, BrokenPersonnelMarker>>(
            goodOrderSingleManCounter => (GoodOrderPersonnelMarker)goodOrderSingleManCounter,
            goodOrderMultiManCounter => (GoodOrderPersonnelMarker)goodOrderMultiManCounter,
            brokenSingleManCounter => (BrokenPersonnelMarker)brokenSingleManCounter,
            brokenMultiManCounter => (BrokenPersonnelMarker)brokenMultiManCounter
        );
    }

    public OneOf<SingleManCounter, MultiManCounter> ToCounter()
    {
        return Match<OneOf<SingleManCounter, MultiManCounter>>(
            goodOrderSingleManCounter => (SingleManCounter)goodOrderSingleManCounter,
            goodOrderMultiManCounter => (MultiManCounter)goodOrderMultiManCounter,
            brokenSingleManCounter => (SingleManCounter)brokenSingleManCounter,
            brokenMultiManCounter => (MultiManCounter)brokenMultiManCounter
        );
    }
}
