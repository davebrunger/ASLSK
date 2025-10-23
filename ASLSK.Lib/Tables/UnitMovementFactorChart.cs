namespace ASLSK.Lib.Tables;

public static class UnitMovementFactorChart
{
    public static Option<int> GetUnitMovementFactor(PersonnelMarker personnelMarker, bool withLeader, bool doubleTime)
    {
        return personnelMarker.ToCounter().Match(
            singleManCounter => singleManCounter.InformationalMarkers.Contains(InformationalMarker.Wounded)
                ? (doubleTime || withLeader ? Option.None : Option.Some(3))
                : Option.Some(doubleTime ? 8 : 6),
            multiManCounter => multiManCounter.Class.Match(
                () => GetExperienceUnitMovementFactor(withLeader, doubleTime),
                () => GetExperienceUnitMovementFactor(withLeader, doubleTime),
                () => GetExperienceUnitMovementFactor(withLeader, doubleTime),
                () => Option.Some(withLeader ? (doubleTime ? 8 : 6) : (doubleTime ? 5 : 3)),
                () => Option.Some(withLeader ? (doubleTime ? 7 : 5) : (doubleTime ? 5 : 3))
            ));
    }

    private static Option<int> GetExperienceUnitMovementFactor(bool withLeader, bool doubleTime)
    {
        return Option.Some(withLeader ? (doubleTime ? 8 : 6) : (doubleTime ? 6 : 4));
    }
}
