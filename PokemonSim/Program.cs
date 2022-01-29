using System;

namespace PokemonSim
{
    public class Program
    {
        static void Main()
        {
            Global.stateStack.Push(new PlayState());
            //the fun never ends
            while (true)
            {
                Global.stateStack.Update();
            }
        }
    }
}