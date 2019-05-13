namespace Farm
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var cat = new Cat();
            var dog = new Dog();

            dog.Eat();
            dog.Bark();

            cat.Eat();
            cat.Meow();
        }
    }
}
