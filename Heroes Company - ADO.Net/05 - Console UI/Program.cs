using Microsoft.Data.SqlClient;
using System;

namespace MatrixHeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            insertHero();
            
        }

        static void insertHero()
        {
            Hero hero = new Hero();
            hero.Ability = "defender";
            hero.HeroId = Guid.NewGuid().ToString();
            hero.TrainerId = "1";
            hero.TrainStartDate = DateTime.Now;
            hero.Name = "AquaMan";
            hero.SuitColors = "red, blue";
            hero.StartingPower = 2.10m;
            hero.CurrentPower = 5.43m;

            //using TrainersStorage heroesStorageHandler = new TrainersStorage();
            //heroesStorageHandler.Insert(hero);
            
           
           
        }
    }
}
