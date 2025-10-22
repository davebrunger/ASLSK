namespace ASLSK.Lib.Counters;

[Option("LightMachineGun")]
[Option("MediumMachineGun")]
[Option("HeavyMachineGun")]
public partial class MachineGunType
{
}

[Option("GoodOrder")]
[Option("Malfunctioned")]
public partial class MachineGunSide
{
}

public record MachineGun
(
    MachineGunType Type,
    int PortagePoints,
    int FirePower,
    int Range,
    int Breakdown,
    MachineGunSide FaceUpSide,
    int RepairDieRoll,
    int EliminationDieRoll
) : ISupportWeapon
{
    public bool Repairable => true;
}