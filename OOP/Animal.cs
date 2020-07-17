namespace ZooApp
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Legs { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        private bool IsSleeping;
        public Animal() { }
        public Animal(string name)
        {
            this.Name = name;
        }
        public string Sleep()
        {
            IsSleeping = true;
            return "Animal is sleeping";
        }

        public string WakeUp()
        {
            IsSleeping = false;
            return "Animal is awake";
        }
        public virtual string Eat(int numberOfBites)
        {
            if (IsSleeping)
                return "Animal is not able to eat, because it's sleeping";
            else
            {

                if (numberOfBites <= 0)
                {
                    return "You are starving, please eat!!";
                }
                else
                {
                    return "Normal chewing, well done!";
                }
            }
        }

    }
}

