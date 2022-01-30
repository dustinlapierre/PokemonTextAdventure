namespace PokemonSim
{
    public class Pokemon
    {
        //which pokemon am I?
        public PokemonDef pokemonData { get; set; }
        public string name { get => pokemonData.name; }
        public PokemonType type { get => pokemonData.type; }

        //muttable properties
        public int level { get; set; }
        public int maxHP { get; set; }
        public int currentHP { get; set; }
        public int xp { get; set; } = 0;
        public int xpRequiredForLevel { get; set; }

        //battle stats
        public int effectiveAttack { get; set; }
        public int effectiveDefense { get; set; }
        public int effectiveSpeed { get; set; }

        //IVs - Unique DNA to make pokemon more individual
        public readonly int hpIV;
        public readonly int attackIV;
        public readonly int defenseIV;
        public readonly int speedIV;

        //Pokemon can know up to 4 attacks at a time
        public Attack[] attackList = {new Tackle(), new Ember(), null, null };

        public Pokemon(PokemonDef pokemonData, int level = 1)
        {
            this.pokemonData = pokemonData;
            this.level = level;
            xpRequiredForLevel = this.level * this.level * 5;

            //IVs are determined randomly
            Random rng = new Random();
            hpIV = rng.Next(0,32);
            attackIV = rng.Next(0, 32);
            defenseIV = rng.Next(0, 32);
            speedIV = rng.Next(0, 32);

            CalculateStats();
        }

        //sets current effective stats based on formula
        public void CalculateStats()
        {
            maxHP = ((2 * pokemonData.baseHP + hpIV) * level) / 100 + level + 10;
            effectiveAttack = ((2 * pokemonData.baseAttack + attackIV) * level)/100 + 5;
            effectiveDefense = ((2 * pokemonData.baseDefense + defenseIV) * level) / 100 + 5;
            effectiveSpeed = ((2 * pokemonData.baseSpeed + speedIV) * level) / 100 + 5;
        }

        public void DoAttack(int attackChoice, Pokemon target)
        {
            attackList[attackChoice].Execute(this, target);
        }

        //get a pokemons name and description
        public string GetDescription()
        {
            return (name + ": " + pokemonData.description);
        }
    }
}