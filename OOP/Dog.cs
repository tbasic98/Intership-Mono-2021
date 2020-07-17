using System;

namespace ZooApp
{
    public class Dog : Animal
    {
        public Dog(string name) : base(name)
        {
            this.Legs = 4;
        }

        public string Fetch(string toy)
        {
            Random random = new Random();
            if (random.Next() % 2 != 0)
            {
                return "You successfully cought a " + toy;
            }
            else
            {
                return "Looser you didn't catch a " + toy;
            }
        }
    }
}
