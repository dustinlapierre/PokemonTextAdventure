namespace PokemonSim
{
    //Pokemon base data as a Strategy
    public abstract class PokemonDef
    {
        public string name { get; set; } = "Missingno";
        public string description { get; set; } = "Unknown";
        public List<PokemonType> type { get; set; } = new List<PokemonType>();
        public int baseHP { get; set; }
        public int baseAttack { get; set; }
        public int baseDefense { get; set; }
        public int baseSpeed { get; set; }
        public Dictionary<int, Attack> learnset = new Dictionary<int, Attack>() { };
    }

    public class Bulbasaur : PokemonDef
    {
        public Bulbasaur()
        {
            name = "Bulbasaur";
            type.Add(PokemonType.GRASS);
            type.Add(PokemonType.POISON);
            baseHP = 45;
            baseAttack = 65;
            baseDefense = 65;
            baseSpeed = 45;
            learnset = new Dictionary<int, Attack>() { { 1, new Tackle() } };
        }
    }
    public class Charmander : PokemonDef
    {
        public Charmander()
        {
            name = "Charmander";
            description = "A fire type pokemon with a flame for a tail.";
            type.Add(PokemonType.FIRE);
            baseHP = 39;
            baseAttack = 60;
            baseDefense = 50;
            baseSpeed = 65;
            learnset = new Dictionary<int, Attack>() { 
                { 1, new Tackle() },
                { 4, new Ember() }
            };
        }
    }
    public class Squirtle : PokemonDef
    {
        public Squirtle()
        {
            name = "Squirtle";
            type.Add(PokemonType.WATER);
            baseHP = 44;
            baseAttack = 50;
            baseDefense = 65;
            baseSpeed = 43;
            learnset = new Dictionary<int, Attack>() { { 1, new Tackle() } };
        }
    }
}
