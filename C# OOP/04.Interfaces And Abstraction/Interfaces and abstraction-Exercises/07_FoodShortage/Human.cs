namespace _07_FoodShortage
{
    public abstract class Human : IBuyer
    {
        private string name;
        private int age;
        private int food;

        public Human(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Food = 0;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public int Food
        {
            get => this.food;
            set => this.food = value;
        }

        public virtual void BuyFood()
        {
        }
    }
}
