using System;

namespace PokemonSim
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the world of Pokemon!");
            Player player = new Player();
            Pokemon chary = new Pokemon(new Charmander(), 10);
            Pokemon bulba = new Pokemon(new Bulbasaur());
            Pokemon squirt = new Pokemon(new Squirtle());
            chary.DoAttack(0, bulba);
            chary.DoAttack(1, bulba);
            chary.DoAttack(1, squirt);
        }
    }
}