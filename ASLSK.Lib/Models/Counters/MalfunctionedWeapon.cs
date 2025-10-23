namespace ASLSK.Lib.Models.Counters;

public record MalfunctionedWeaponRepairErrorDetails
(
    MalfunctionedWeapon MalfunctionedWeapon,
    DieRoll DieRoll
);

[Option("WeaponEliminated", OfType = typeof(MalfunctionedWeaponRepairErrorDetails))]
[Option("RepairFailed", OfType = typeof(MalfunctionedWeaponRepairErrorDetails))]
public partial class MalfunctionedWeaponRepairError
{
}

public record MalfunctionedWeapon
(
    Nationality Nationality,
    RepairableWeaponType Type,
    PositiveInteger PortagePoints,
    PositiveInteger FirePower,
    PositiveInteger Range,
    DiceRoll Breakdown,
    DieRoll RepairDieRoll,
    DieRoll EliminationDieRoll
)
{
    public Result<RepairableWeapon, MalfunctionedWeaponRepairError> Repair(DieRoll dieRoll)
    {
        if (dieRoll >= EliminationDieRoll)
        {
            return MalfunctionedWeaponRepairError.WeaponEliminated(new MalfunctionedWeaponRepairErrorDetails(this, dieRoll));
        }
        if (dieRoll > RepairDieRoll)
        {
            return MalfunctionedWeaponRepairError.RepairFailed(new MalfunctionedWeaponRepairErrorDetails(this, dieRoll));
        }
        return new RepairableWeapon(
            Nationality,
            Type,
            PortagePoints,
            FirePower,
            Range,
            Breakdown,
            RepairDieRoll,
            EliminationDieRoll
        );
    }
}