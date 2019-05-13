namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;

        public Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        public string Name
        {
            get=>this.name; 
            set
            {
                this.name = value;
            }
        }

        public string FavouriteFood
        {
            get=>favouriteFood; 
            set
            {
                this.favouriteFood = value;
            }
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
        }
    }
}
