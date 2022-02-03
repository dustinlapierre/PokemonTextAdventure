namespace PokemonSim
{
    public class Route1 : Location
    {
        public Route1()
        {
            name = "Route 1";
            options.Add("Search Grass");
            options.Add("Travel to Viridian City");
            options.Add("Travel to Pallet Town");
        }

        public override void Explore(int option)
        {
            switch (option)
            {
                case 0:
                    Global.stateStack.Push(new BattleState());
                    break;
                case 2:
                    Global.location = new PalletTown();
                    Console.WriteLine("You traveled SOUTH to Pallet Town!");
                    Thread.Sleep(2500);
                    break;
                default:
                    Console.WriteLine("Oops not implemented yet!");
                    Thread.Sleep(2500);
                    break;
            }
        }
    }
}
