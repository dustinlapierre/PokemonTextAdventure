using System.Globalization;

namespace PokemonSim
{
    public class StartState : State
    {
        public override void Enter()
        {
            Console.WriteLine("Welcome to the world of Pokemon!");
            Console.WriteLine("What's your name?");
            string userName = Console.ReadLine();
            userName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userName);
            Console.WriteLine("Hello " + userName + "! Let's get you started with your first Pokemon!");
        }
    }
}
