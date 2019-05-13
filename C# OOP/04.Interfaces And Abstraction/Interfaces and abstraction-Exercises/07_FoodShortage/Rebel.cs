namespace _07_FoodShortage
{
    public class Rebel : Human
    {
        private string group;

        public Rebel(string name, int age, string group) 
            : base(name,age)
        {
            this.Group = group;
        }

        public string Group
        {
            get => this.group;
            set => this.group = value;
        }

        public override void BuyFood()
        {
            this.Food += 5;
        }
    }
}
