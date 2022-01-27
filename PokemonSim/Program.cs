using System;

namespace PokemonSim
{
    internal class Program
    {
        static void Main()
        {
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