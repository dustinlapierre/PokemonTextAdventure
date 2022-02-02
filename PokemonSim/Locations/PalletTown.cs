namespace PokemonSim
{
    public class PalletTown : Location
    {
        public PalletTown()
        {
            name = "Pallet Town";
            options.Add("Talk to Mom");
            options.Add("Travel to Route 1");
        }

        public override void Explore(int option)
        {
            switch (option)
            {
                case 0:
                    Console.WriteLine(Global.player.name.ToUpper() + "! Why not take a short rest.");
                    Thread.Sleep(1500);
                    Console.Write("Z");
                    Thread.Sleep(1000);
                    Console.Write("z");
                    Thread.Sleep(1000);
                    Console.Write("z");
                    Thread.Sleep(250);
                    Console.Write(".");
                    Thread.Sleep(250);
                    Console.Write(".");
                    Thread.Sleep(500);
                    Console.Write(".\n");
                    Global.player.HealParty();
                    Console.WriteLine("Oh good! You and your POKEMON are looking great! Take care now!");
                    break;
                default:
                    Global.location = new Route1();
                    Console.WriteLine("You traveled NORTH to Route 1!");
                    break;
            }
            Thread.Sleep(2500);
        }
    }
}
