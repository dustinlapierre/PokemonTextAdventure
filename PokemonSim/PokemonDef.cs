namespace PokemonSim
{
    //Pokemon base data as a Strategy
    public abstract class PokemonDef
    {
        public string name { get; set; } = "Missingno";
        public string description { get; set; } = "Unknown";
        public List<PokemonType> type { get; set; } = new List<PokemonType>();
        public int evolvesInto { get; set; } = -1;//pokedex number of pokemon I evolve into
        public int evolvesAt { get; set; } = 0; //zero means no evolution
        public double baseHP { get; set; }
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
            description = "The GRASS/POISON type POKéMON with a seed planted on its back.";
            type.Add(PokemonType.GRASS);
            type.Add(PokemonType.POISON);
            baseHP = 45;
            baseAttack = 65;
            baseDefense = 65;
            baseSpeed = 45;
            learnset = new Dictionary<int, Attack>() { 
                { 1, new Tackle() },
                { 3, new VineWhip() },
            };
        }
    }
    public class Charmander : PokemonDef
    {
        public Charmander()
        {
            name = "Charmander";
            description = "The FIRE type lizard POKéMON with a flame on its tail.";
            type.Add(PokemonType.FIRE);
            evolvesInto = 1; //this temporarily evolves into Bulbasaur
            evolvesAt = 6; //should be 16
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
            description = "The WATER type tiny turtle POKéMON.";
            type.Add(PokemonType.WATER);
            baseHP = 44;
            baseAttack = 50;
            baseDefense = 65;
            baseSpeed = 43;
            learnset = new Dictionary<int, Attack>() { 
                { 1, new Tackle() },
                { 3, new WaterGun() }
            };
        }
    }
}
