namespace PokemonSim
{
    //globally scoped vars used for game world
    public static class Global
    {
        public static StateMachine stateStack = new StateMachine();
        public static Location location = new PalletTown();
        public static Player player;

        //pokedex maps pokemon ID to definitions
        public static Dictionary<int, PokemonDef> pokeDex = new Dictionary<int, PokemonDef>()
        {
            {1, new Bulbasaur()},
            {4, new Charmander()},
            {7, new Squirtle()},
        };
    }
}
