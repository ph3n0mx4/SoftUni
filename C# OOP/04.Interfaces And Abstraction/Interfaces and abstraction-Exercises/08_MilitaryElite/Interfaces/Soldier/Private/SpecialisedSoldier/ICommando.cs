namespace _08_MilitaryElite.Interfaces.Soldier.Private.SpecialisedSoldier
{
    using _08_MilitaryElite.Classes.Soldiers.Privates.SpecialisedSoldiers.Sets;
    using System.Collections.Generic;

    public interface ICommando
    {
        List<Mission> Missions { get; }
    }
}
