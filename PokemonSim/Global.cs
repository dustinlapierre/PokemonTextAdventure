namespace PokemonSim
{
    //globally scoped vars used for game world
    public static class Global
    {
        public static StateMachine stateStack = new StateMachine();
        public static Location location = new PalletTown();
        public static Player player;
    }
}
