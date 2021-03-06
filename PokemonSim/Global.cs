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
            {2, new Ivysaur()},
            {4, new Charmander()},
            {5, new Charmeleon()},
            {7, new Squirtle()},
            {8, new Wartortle()},
            {16, new Pidgey()},
        };
    }
}
