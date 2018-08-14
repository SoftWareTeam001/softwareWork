using System;
namespace Birds
{
    class Animal
    {
        bool hasTwoFeet;
        bool isThermostatic;
        bool isOviparous;
        bool hasFeather;
        public Animal(bool hasTwoFeet, bool isThermostatic,bool isOviparous,bool hasFeather)
        {
            this.hasFeather = hasFeather;
            this.hasTwoFeet = hasTwoFeet;
            this.isOviparous = isOviparous;
            this.isThermostatic = isThermostatic;
        }
        public bool IsBird()
        {
            if(hasTwoFeet && isThermostatic && isOviparous && hasFeather)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
    class Penguin : Animal
    {
        public Penguin():base(true,true,true,true)
        { }
    }
    class Eagle :Animal
    {
        public Eagle():base(true,true,true,true)
        { }
    }
    class Fowl :Animal
    {
        public Fowl():base(true,true,true,true)
        { }
    }
    class JudgeFunction
    {
        static void Main(String[] args)
        {
            Eagle eagle = new Eagle();
            Penguin penguin = new Penguin();
            Fowl fowl = new Fowl();

            Animal[] animalList = { eagle, penguin, fowl };
            
            foreach(Animal eachAnimal in animalList)
            {
                if (eachAnimal.IsBird())
                {
                    Console.WriteLine("{0} is bird \n", eachAnimal);
                }
                else
                {
                    Console.WriteLine("{0} is not bird \n", eachAnimal);
                }
            }
            Console.ReadKey();
        }
    }
}