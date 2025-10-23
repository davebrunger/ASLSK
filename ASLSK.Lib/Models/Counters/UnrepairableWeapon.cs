namespace ASLSK.Lib.Models.Counters;

[Option("FlameThrower")]
[Option("DemolitionCharge")]
public partial class UnrepairableWeaponType
{
}

public record UnrepairableWeapon
(
    Nationality Nationality,
    UnrepairableWeaponType Type,
    PositiveInteger PortagePoints,
    PositiveInteger FirePower,
    PositiveInteger Range,
    DiceRoll Breakdown
);