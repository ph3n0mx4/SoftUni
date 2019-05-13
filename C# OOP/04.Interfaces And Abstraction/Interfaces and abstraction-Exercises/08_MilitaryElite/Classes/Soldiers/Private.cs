namespace _08_MilitaryElite.Classes.Soldiers
{
    using _08_MilitaryElite.Interfaces.Soldier;

    public class Private : Soldier, IPrivate
    {
        private decimal salary;

        public Private(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary
        {
            get => salary;
            private set => salary = value;
        }

        public override string ToString()
        {//Name: <firstName> <lastName> Id: <id> Salary: <salary>
            return $"{base.ToString()} Salary: {this.Salary:f2}";
        }
    }
}
