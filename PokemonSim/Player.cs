namespace PokemonSim
{
    //the player character, which doubles as the game controller
    public class Player
    {
        public Pokemon[] party = { null, null, null, null, null, null };
        public string name { get; set; }
        public int numBadges = 0;
        public int money = 0;
        //public List<Item> bag = new List<Item>();
        //location
        //state
    }
}
