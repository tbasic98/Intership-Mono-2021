using System;

namespace ZooApp
{
    public class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
            this.Legs = 4;
        }

        public string CatchMice()
        {
            Random random = new Random();
            if (random.Next() % 2 == 0)
            {
                return "You caught a mouse!\nWell done!";
            }
            else
            {
                return "The mouse run away!\nYou are a bad cat!";
            }
        }
    }
}
