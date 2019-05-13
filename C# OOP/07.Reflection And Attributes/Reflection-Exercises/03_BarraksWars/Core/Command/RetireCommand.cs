using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Command
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];
            string output;
            //IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            try
            {
                this.Repository.RemoveUnit(unitType);
                output = unitType + " retired!";
            }
            catch (Exception e)
            {

                return e.Message;
            }
            
            return output;
            
        }
    }
}
