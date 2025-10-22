namespace ASLSK.Lib.Counters;

public class Counter : OneOfBase<InformationalMarker, PersonelMarker, SupportWeapon>
{
    protected Counter(OneOf<InformationalMarker, PersonelMarker, SupportWeapon> input) : base(input)
    {
    }

    public static implicit operator Counter(InformationalMarker informationalMarker) => new(informationalMarker);
    public static implicit operator Counter(PersonelMarker personelMarker) => new(personelMarker);
    public static implicit operator Counter(SupportWeapon supportWeapon) => new(supportWeapon);
}
