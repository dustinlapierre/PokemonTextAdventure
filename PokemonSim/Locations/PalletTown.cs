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
            Console.WriteLine("Oops not implemented yet!");
            Thread.Sleep(2000);
        }
    }
}
