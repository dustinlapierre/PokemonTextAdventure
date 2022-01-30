namespace PokemonSim
{
    public abstract class Location
    {
        public List<string> options { get; set; } = new List<string>();
        public string name { get; set; } = "Default Town";
        public abstract void Explore(int option);
    }
}
