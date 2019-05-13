namespace _08_MilitaryElite.Interfaces.Soldier.Private.SpecialisedSoldier.Sets
{
    public interface IMission
    {
        string CodeName { get; }
        string State { get; }
        void CompleteMission();
    }
}
