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
            //15% chance trainer encounter when trying actions here
            Random rng = new Random();
            if (rng.Next(1, 101) <= 15)
            {
                Trainer joey = new Trainer(
                    new Pokemon(new Pidgey(), 4),
                    new Pokemon(new Pidgey(), 4)
                    );
                joey.name = "Trainer Joey";

                Global.stateStack.Push(new BattleState(joey, true, 250));
                return;
            }

            switch (option)
            {
                case 0:
                    List<PokemonDef> encounters = new List<PokemonDef>();
                    encounters.Add(new Pidgey());

                    Trainer wildEncounter = new Trainer(
                                new Pokemon(encounters[rng.Next(encounters.Count)], rng.Next(2, 5))
                                );
                    Global.stateStack.Push(new BattleState(wildEncounter));
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
