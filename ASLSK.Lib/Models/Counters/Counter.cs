namespace ASLSK.Lib.Models.Counters;

[Option("American")]
[Option("German")]
public partial class Nationality
{
}   

public class Counter : OneOfBase<InformationalMarker, PersonnelMarker, SupportWeapon>
{
    protected Counter(OneOf<InformationalMarker, PersonnelMarker, SupportWeapon> input) : base(input)
    {
    }

    public static implicit operator Counter(InformationalMarker informationalMarker) => new(informationalMarker);
    public static implicit operator Counter(PersonnelMarker personnelMarker) => new(personnelMarker);
    public static implicit operator Counter(SupportWeapon supportWeapon) => new(supportWeapon);
}
