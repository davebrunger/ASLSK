namespace ASLSK.Lib.Models.Counters;

[Option("LightMachineGun")]
[Option("MediumMachineGun")]
[Option("HeavyMachineGun")]
public partial class RepairableWeaponType
{
}


public record RepairableWeapon
(
    Nationality Nationality,
    RepairableWeaponType Type,
    PositiveInteger PortagePoints,
    PositiveInteger FirePower,
    PositiveInteger Range,
    DiceRoll Breakdown,
    DieRoll RepairDieRoll,
    DieRoll EliminationDieRoll
);
