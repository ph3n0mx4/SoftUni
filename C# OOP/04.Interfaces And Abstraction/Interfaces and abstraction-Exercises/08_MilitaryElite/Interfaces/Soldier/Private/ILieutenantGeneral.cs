namespace _08_MilitaryElite.Interfaces.Soldier.Private
{
    using System.Collections.Generic;
    using _08_MilitaryElite.Classes.Soldiers;

    public interface ILieutenantGeneral
    {
        List<Private> Privates { get; }
    }
}
