namespace ASLSK.Lib.Counters;

public interface ISupportWeapon
{
    int PortagePoints { get; }
    int FirePower { get; }
    int Range { get; }
    int Breakdown { get; }
    bool Repairable { get; }
}

public class SupportWeapon : OneOfBase<MachineGun, FlameThrower, DemolitionCharge>, ISupportWeapon
{
    protected SupportWeapon(OneOf<MachineGun, FlameThrower, DemolitionCharge> input) : base(input)
    {
    }

    public static implicit operator SupportWeapon(MachineGun machineGun) => new(machineGun);
    public static implicit operator SupportWeapon(FlameThrower flameThrower) => new(flameThrower);
    public static implicit operator SupportWeapon(DemolitionCharge demolitionCharge) => new(demolitionCharge);

    public int PortagePoints => Match(
        machineGun => machineGun.PortagePoints,
        flameThrower => flameThrower.PortagePoints,
        demolitionCharge => demolitionCharge.PortagePoints
    );

    public int FirePower => Match(
        machineGun => machineGun.FirePower,
        flameThrower => flameThrower.FirePower,
        demolitionCharge => demolitionCharge.FirePower
    );

    public int Range => Match(
        machineGun => machineGun.Range,
        flameThrower => flameThrower.Range,
        demolitionCharge => demolitionCharge.Range
    );

    public int Breakdown => Match(
        machineGun => machineGun.Breakdown,
        flameThrower => flameThrower.Breakdown,
        demolitionCharge => demolitionCharge.Breakdown
    );

    public bool Repairable => Match(
        machineGun => machineGun.Repairable,
        flameThrower => flameThrower.Repairable,
        demolitionCharge => demolitionCharge.Repairable
    );
}