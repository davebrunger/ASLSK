namespace ASLSK.Lib.Models.Counters;

public record AttemptErrorDetails(
    GoodOrderPersonnelMarker PersonnelMarker,
    SupportWeapon SupportWeapon
);

public record AttemptFailedDetails(
    GoodOrderPersonnelMarker PersonnelMarker,
    SupportWeapon SupportWeapon,
    int ModifiedDieRoll
);

[Option("UnitNotInGoodOrder", OfType = typeof(AttemptErrorDetails))]
[Option("RecoveryFailed", OfType = typeof(AttemptFailedDetails))]
public partial class RecoveryError
{
}

[Option("UnitNotInGoodOrder", OfType = typeof(AttemptErrorDetails))]
[Option("WeaponNotRepairable", OfType = typeof(AttemptErrorDetails))]
[Option("UnitDoesNotPossessWeapon", OfType = typeof(AttemptErrorDetails))]
[Option("InvalidNationality", OfType = typeof(AttemptErrorDetails))]
[Option("WeaponInGoodOrder", OfType = typeof(AttemptErrorDetails))]
[Option("WeaponEliminated", OfType = typeof(AttemptFailedDetails))]
[Option("RepairFailed", OfType = typeof(AttemptFailedDetails))]
public partial class RepairError
{
}

public class GoodOrderPersonnelMarker : OneOfBase<GoodOrderSingleManCounter, GoodOrderMultiManCounter>
{
    protected GoodOrderPersonnelMarker(OneOf<GoodOrderSingleManCounter, GoodOrderMultiManCounter> input) : base(input)
    {
    }
    public static implicit operator GoodOrderPersonnelMarker(GoodOrderSingleManCounter singleManCounter) => new(singleManCounter);
    public static implicit operator GoodOrderPersonnelMarker(GoodOrderMultiManCounter multiManCounter) => new(multiManCounter);

    public Nationality Nationality => Match(
        singleManCounter => singleManCounter.Nationality,
        multiManCounter => multiManCounter.Nationality
    );

    public ImmutableHashSet<InformationalMarker> InformationalMarkers => Match(
        singleManCounter => singleManCounter.InformationalMarkers,
        multiManCounter => multiManCounter.InformationalMarkers
    );

    public ImmutableList<SupportWeapon> SupportWeapons => Match(
        singleManCounter => singleManCounter.SupportWeapons,
        multiManCounter => multiManCounter.SupportWeapons
    );

    public Result<GoodOrderPersonnelMarker, RecoveryError> Recover(SupportWeapon supportWeapon, int dieRoll)
    {
        int modifiedDieRoll = dieRoll + (InformationalMarkers.Contains(InformationalMarker.CounterExhausted) ? 1 : 0);
        if (modifiedDieRoll >= 6)
        {
            return RecoveryError.RecoveryFailed(new AttemptFailedDetails(this, supportWeapon, modifiedDieRoll));
        }
        return Match<GoodOrderPersonnelMarker>(
            singleManCounter => singleManCounter with { SupportWeapons = singleManCounter.SupportWeapons.Add(supportWeapon) },
            multiManCounter => multiManCounter with { SupportWeapons = multiManCounter.SupportWeapons.Add(supportWeapon) });
    }

    public Result<GoodOrderPersonnelMarker, RepairError> Repair(MalfunctionedWeapon malfunctionedWeapon, DieRoll dieRoll)
    {
        if (!SupportWeapons.Contains(malfunctionedWeapon))
        {
            return RepairError.UnitDoesNotPossessWeapon(new AttemptErrorDetails(this, malfunctionedWeapon));
        }
        if (Nationality != malfunctionedWeapon.Nationality)
        {
            return RepairError.InvalidNationality(new AttemptErrorDetails(this, malfunctionedWeapon));
        }
        return malfunctionedWeapon.Repair(dieRoll).Match<Result<GoodOrderPersonnelMarker, RepairError>>(
            repairableWeapon => Match<GoodOrderPersonnelMarker>(
                singleManCounter => singleManCounter with
                {
                    SupportWeapons = singleManCounter.SupportWeapons.Remove(malfunctionedWeapon).Add(repairableWeapon)
                },
                multiManCounter => multiManCounter with
                {
                    SupportWeapons = multiManCounter.SupportWeapons.Remove(malfunctionedWeapon).Add(repairableWeapon)
                }
            ),
            error => error.Match(
                weaponEliminated => RepairError.WeaponEliminated(new AttemptFailedDetails(this, malfunctionedWeapon, dieRoll)),
                repairFailed => RepairError.RepairFailed(new AttemptFailedDetails(this, malfunctionedWeapon, dieRoll))
            )
        );
    }
}
