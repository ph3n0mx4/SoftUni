namespace _07_FoodShortage
{
    public class Citizen : Human
    {//“<name> <age> <id> <birthdate>
        private string id;
        private string birthdate;
        private int food;

        public Citizen(string name, int age, string id, string birthdate) 
            : base(name, age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Birthdate
        {
            get => this.birthdate;
            set => this.birthdate = value;
        }

        public string Id
        {
            get => this.id;
            set => this.id = value;
        }

        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
