namespace ASLSK.Lib.Counters;

public record FlameThrower
(
    int PortagePoints,
    int FirePower,
    int Range,
    int Breakdown
) : ISupportWeapon
{
    public bool Repairable => false;
}