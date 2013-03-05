using System;

class Dog : Animal
{
    public Dog(string name, int age, Sex sex)
        : base(name, age, sex)
    {
    }

    public override string ProduceSound()
    {
        return "Dog produced sound.";
    }
}
