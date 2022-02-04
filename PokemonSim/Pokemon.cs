﻿namespace PokemonSim
{
    public class Pokemon
    {
        //which pokemon am I?
        public PokemonDef pokemonData { get; set; }
        public string name { get => pokemonData.name; }
        public List<PokemonType> type { get => pokemonData.type; }

        //muttable properties
        public int level { get; set; }
        public double maxHP { get; set; }
        public double currentHP { get; set; }
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
            currentHP = maxHP;
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

        //returns a pokemon's menu entry (as seen in menus and battle)
        public string GetMenuText()
        {
            string text = "";
            //name and level
            text += String.Format("LV. {0} {1}", level, name);
            //types
            foreach (PokemonType type in type)
            {
                text += String.Format(" " + type.ToString() + " ");
            }
            //status
            text += String.Format("| HP: {0}/{1}", currentHP, maxHP);

            return text;
        }

        //draws a healthbar for this pokemon of the given length
        public void DrawHealthBar(int charLength)
        {
            double healthBlocks = (currentHP / maxHP) * charLength;
            Console.Write("[");
            for (int i = 0; i < charLength; i++)
            {
                if (healthBlocks > 0)
                {
                    Console.Write("■");
                    healthBlocks -= 1;
                }
                else
                {
                    Console.Write("  ");
                }
            }
            Console.Write("] HP:" + Math.Floor(currentHP) + "/" + Math.Floor(maxHP) + "\n");
        }
    }
}