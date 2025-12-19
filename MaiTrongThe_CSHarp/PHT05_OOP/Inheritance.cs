using System;

namespace Inheritance
{
    class Animal
    {
        public string Name { get; set; }

        public virtual void MakeSound()
        {
            Console.WriteLine("The animal makes a sound.");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof! Woof!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            animal.Name = "Generic Animal";
            animal.MakeSound();

            Dog dog = new Dog();
            dog.Name = "Buddy";
            dog.MakeSound();

            Console.ReadLine();
        }
    }
}