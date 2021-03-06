namespace PokemonSim
{
    //Pokemon base data as a Strategy
    public abstract class PokemonDef
    {
        public string name { get; set; } = "Missingno";
        public string description { get; set; } = "Unknown";
        public List<PokemonType> type { get; set; } = new List<PokemonType>();
        public int evolvesInto { get; set; } = -1; //pokedex number of the pokemon I evolve into (-1 means no evolution)
        public int evolvesAt { get; set; } = 0; //when a pokemon levels up and is >= this number, they evolve
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
            evolvesInto = 2;
            evolvesAt = 16;
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
    public class Ivysaur : PokemonDef
    {
        public Ivysaur()
        {
            name = "Ivysaur";
            description = "Exposure to sunlight adds to its strength. Sunlight also makes the bud on its back grow larger.";
            type.Add(PokemonType.GRASS);
            type.Add(PokemonType.POISON);
            baseHP = 60;
            baseAttack = 80;
            baseDefense = 80;
            baseSpeed = 60;
            learnset = new Dictionary<int, Attack>() {
                { 1, new VineWhip() }
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
            evolvesInto = 5;
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
    public class Charmeleon : PokemonDef
    {
        public Charmeleon()
        {
            name = "Charmeleon";
            description = "When it swings its burning tail, it elevates the temperature to unbearably high levels.";
            type.Add(PokemonType.FIRE);
            baseHP = 58;
            baseAttack = 80;
            baseDefense = 65;
            baseSpeed = 80;
            learnset = new Dictionary<int, Attack>() {
                { 1, new Ember() }
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
            evolvesInto = 8;
            evolvesAt = 16;
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
    public class Wartortle : PokemonDef
    {
        public Wartortle()
        {
            name = "Wartortle";
            description = "It cleverly controls its furry ears and tail to maintain its balance while swimming.";
            type.Add(PokemonType.WATER);
            baseHP = 59;
            baseAttack = 65;
            baseDefense = 80;
            baseSpeed = 58;
            learnset = new Dictionary<int, Attack>() {
                { 1, new WaterGun() }
            };
        }
    }
    public class Pidgey : PokemonDef
    {
        public Pidgey()
        {
            name = "Pidgey";
            description = "It is docile and prefers to avoid conflict. If disturbed, however, it can ferociously strike back.";
            type.Add(PokemonType.NORMAL);
            type.Add(PokemonType.FLYING);
            baseHP = 40;
            baseAttack = 45;
            baseDefense = 40;
            baseSpeed = 56;
            learnset = new Dictionary<int, Attack>() {
                { 1, new Tackle() },
                { 9, new Gust() },
            };
        }
    }
}
