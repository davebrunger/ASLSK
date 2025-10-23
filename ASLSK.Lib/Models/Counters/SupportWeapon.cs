namespace ASLSK.Lib.Models.Counters;

public class SupportWeaponType : OneOfBase<RepairableWeaponType, UnrepairableWeaponType>
{
    protected SupportWeaponType(OneOf<RepairableWeaponType, UnrepairableWeaponType> input) : base(input)
    {
    }

    public static implicit operator SupportWeaponType(RepairableWeaponType repairableWeaponType) => new(repairableWeaponType);
    public static implicit operator SupportWeaponType(UnrepairableWeaponType unrepairableWeaponType) => new(unrepairableWeaponType);
}

public class SupportWeapon : OneOfBase<RepairableWeapon, MalfunctionedWeapon, UnrepairableWeapon>
{
    protected SupportWeapon(OneOf<RepairableWeapon, MalfunctionedWeapon, UnrepairableWeapon> input) : base(input)
    {
    }

    public static implicit operator SupportWeapon(RepairableWeapon repairableWeapon) => new(repairableWeapon);
    public static implicit operator SupportWeapon(MalfunctionedWeapon malfunctionedWeapon) => new(malfunctionedWeapon);
    public static implicit operator SupportWeapon(UnrepairableWeapon unrepairableWeapon) => new(unrepairableWeapon);

    public SupportWeaponType Type => Match<SupportWeaponType>(
        repairableWeapon => repairableWeapon.Type,
        malfunctionedWeapon => malfunctionedWeapon.Type,
        unrepairableWeapon => unrepairableWeapon.Type
    );
}