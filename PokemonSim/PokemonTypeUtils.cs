namespace PokemonSim
{
    //global pokemon types
    public enum PokemonType
    {
        NORMAL,
        FIRE,
        WATER,
        GRASS,
        POISON,
        FLYING
    }
    //static helper methods used to determine type effectiveness
    public static class PokemonTypeUtils
    {
        static readonly Dictionary<(PokemonType, PokemonType), double> typeChart = new Dictionary<(PokemonType, PokemonType), double>()
        {
            { (PokemonType.FIRE, PokemonType.FIRE), 0.5},
            { (PokemonType.FIRE, PokemonType.WATER), 0.5},
            { (PokemonType.FIRE, PokemonType.GRASS), 2},
            { (PokemonType.FIRE, PokemonType.POISON), 1},
            { (PokemonType.FIRE, PokemonType.NORMAL), 1},
            { (PokemonType.FIRE, PokemonType.FLYING), 1},

            { (PokemonType.GRASS, PokemonType.FIRE), 0.5},
            { (PokemonType.GRASS, PokemonType.WATER), 2},
            { (PokemonType.GRASS, PokemonType.GRASS), 0.5},
            { (PokemonType.GRASS, PokemonType.POISON), 0.5},
            { (PokemonType.GRASS, PokemonType.NORMAL), 1},
            { (PokemonType.GRASS, PokemonType.FLYING), 0.5},

            { (PokemonType.WATER, PokemonType.FIRE), 2},
            { (PokemonType.WATER, PokemonType.GRASS), 0.5},
            { (PokemonType.WATER, PokemonType.WATER), 0.5},
            { (PokemonType.WATER, PokemonType.POISON), 1},
            { (PokemonType.WATER, PokemonType.NORMAL), 1},
            { (PokemonType.WATER, PokemonType.FLYING), 1},

            { (PokemonType.POISON, PokemonType.FIRE), 1},
            { (PokemonType.POISON, PokemonType.GRASS), 2},
            { (PokemonType.POISON, PokemonType.WATER), 1},
            { (PokemonType.POISON, PokemonType.POISON), 0.5},
            { (PokemonType.POISON, PokemonType.NORMAL), 1},
            { (PokemonType.POISON, PokemonType.FLYING), 1},

            { (PokemonType.NORMAL, PokemonType.FIRE), 1},
            { (PokemonType.NORMAL, PokemonType.GRASS), 1},
            { (PokemonType.NORMAL, PokemonType.WATER), 1},
            { (PokemonType.NORMAL, PokemonType.POISON), 1},
            { (PokemonType.NORMAL, PokemonType.NORMAL), 1},
            { (PokemonType.NORMAL, PokemonType.FLYING), 1},

            { (PokemonType.FLYING, PokemonType.FIRE), 1},
            { (PokemonType.FLYING, PokemonType.GRASS), 2},
            { (PokemonType.FLYING, PokemonType.WATER), 1},
            { (PokemonType.FLYING, PokemonType.POISON), 1},
            { (PokemonType.FLYING, PokemonType.NORMAL), 1},
            { (PokemonType.FLYING, PokemonType.FLYING), 1},
        };

        public static double GetTypeDamageModifier(PokemonType a, PokemonType b)
        {
            double modifier = 1;
            if(typeChart.ContainsKey((a,b)))
                modifier *= typeChart[(a, b)];

            return modifier;
        }
    }
}
