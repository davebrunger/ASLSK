using OneOf;

namespace ASLSK.Lib.Counters;

public class Counter : OneOfBase<InformationalMarker, PersonelMarker, SupportWeapon>
{
    protected Counter(OneOf<InformationalMarker, PersonelMarker, SupportWeapon> input) : base(input)
    {
    }

    public static implicit operator Counter(InformationalMarker informationalMarker) => new Counter(informationalMarker);
    public static implicit operator Counter(PersonelMarker personelMarker) => new Counter(personelMarker);
    public static implicit operator Counter(SupportWeapon supportWeapon) => new Counter(supportWeapon);
}
