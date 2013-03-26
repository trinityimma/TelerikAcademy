using System;
using System.Linq;

namespace AcademyEcosystem
{
    class AdvancedEngine : Engine
    {
        protected override void ExecuteBirthCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "wolf":
                    this.AddOrganism(new Wolf(commandWords[2], Point.Parse(commandWords[3])));
                    break;

                case "lion":
                    this.AddOrganism(new Lion(commandWords[2], Point.Parse(commandWords[3])));
                    break;

                case "grass":
                    this.AddOrganism(new Grass(Point.Parse(commandWords[2])));
                    break;

                case "boar":
                    this.AddOrganism(new Boar(commandWords[2], Point.Parse(commandWords[3])));
                    break;

                case "zombie":
                    this.AddOrganism(new Zombie(commandWords[2], Point.Parse(commandWords[3])));
                    break;

                default:
                    base.ExecuteBirthCommand(commandWords);
                    break;
            }
        }
    }

    class Wolf : Animal, ICarnivore
    {
        public Wolf(string name, Point location)
            : base(name, location, size: 4)
        {
            return;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal == null || !(animal.Size <= this.Size || animal.State == AnimalState.Sleeping))
                return 0;

            return animal.GetMeatFromKillQuantity();
        }
    }

    class Lion : Animal, ICarnivore
    {
        public Lion(string name, Point location)
            : base(name, location, size: 6)
        {
            return;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal == null || !(animal.Size <= this.Size * 2))
                return 0;

            this.Size++;

            return animal.GetMeatFromKillQuantity();
        }
    }

    class Grass : Plant
    {
        public Grass(Point position)
            : base(position, 2)
        {
            return;
        }

        public override void Update(int time)
        {
            if (this.IsAlive)
                this.Size += time;
        }
    }

    class Boar : Animal, ICarnivore, IHerbivore
    {
        private int biteSize = 2;

        public Boar(string name, Point location)
            : base(name, location, size: 4)
        {
            return;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal == null || !(animal.Size <= this.Size))
                return 0;

            return animal.GetMeatFromKillQuantity();
        }

        public int EatPlant(Plant p)
        {
            if (p == null)
                return 0;

            int eaten = p.GetEatenQuantity(this.biteSize);

            if (eaten != 0)
                this.Size++;

            return eaten;
        }
    }

    class Zombie : Animal
    {
        public Zombie(string name, Point location)
            : base(name, location, size: 0)
        {
            return;
        }

        public override int GetMeatFromKillQuantity()
        {
            return 10;
        }
    }
}
