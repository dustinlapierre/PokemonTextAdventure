namespace PokemonSim
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
        public bool evolve { get; set; }

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
        public Attack[] attackList = {null, null, null, null };

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

            GenerateMoveset();
        }
        //can give a pokemon ID instead of a definition object
        public Pokemon(int pokeID, int level = 1) : this(Global.pokeDex[pokeID], level) { }

        //sets current effective stats based on formula
        private void CalculateStats()
        {
            maxHP = Math.Ceiling(((2 * pokemonData.baseHP + hpIV) * level) / 100 + level + 10);
            effectiveAttack = ((2 * pokemonData.baseAttack + attackIV) * level)/100 + 5;
            effectiveDefense = ((2 * pokemonData.baseDefense + defenseIV) * level) / 100 + 5;
            effectiveSpeed = ((2 * pokemonData.baseSpeed + speedIV) * level) / 100 + 5;
        }

        //simulates leveling to give pokemon a level accurate moveset
        private void GenerateMoveset()
        {
            //for each level up to the current one
            for(int i = 1;i < level; i++)
            {
                //Add move if one is learned at this level
                CheckLearn(i);
            }
        }

        //check if a move is learned at this level and learn it
        private void CheckLearn(int levelToCheck, bool withUI = false)
        {
            if (pokemonData.learnset.ContainsKey(levelToCheck))
            {
                LearnMove(pokemonData.learnset[levelToCheck], withUI);
            }
        }

        //adds a given attack to the pokemon's next empty move slot
        //if no slots exist, a random move is overwritten
        public void LearnMove(Attack move, bool withUI = false)
        {
            for(int i = 0; i< attackList.Length; i++)
            {
                //null slot found, add it and exit method
                if(attackList[i] == null)
                {
                    attackList[i] = move;
                    if(withUI)
                    {
                        Console.WriteLine(name + " learned " + move.attackName + "!");
                        Thread.Sleep(2000);
                    }
                    return;
                }
            }
            //no empty slots left, random overwrite 
            if(!withUI)
            {
                Random rng = new Random();
                attackList[rng.Next(0, 4)] = move;
            }
            //if UI then the player chooses which move to replace
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

            text += "| ";

            //status
            if (currentHP > 0)
                text += String.Format("HP: {0}/{1}", (int)currentHP, (int)maxHP);
            else
                text += "FAINTED";

            return text;
        }

        //returns an array of attack names this pokemon knows
        public string[] GetAttackList()
        {
            List<string> list = new List<string>();
            foreach(Attack attack in attackList)
            {
                if(attack != null)
                    list.Add(attack.attackName + " | POWER: " + attack.basePower + " | TYPE: " + attack.attackType.ToString());
            }
            return list.ToArray();
        }

        //draws a healthbar for this pokemon of the given length
        public void DrawHealthBar(int charLength)
        {
            Console.WriteLine(name + " LV. " + level);
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
            Console.Write("] HP:" + Math.Max(Math.Ceiling(currentHP), 0) + "/" + Math.Ceiling(maxHP) + "\n");
        }
        
        //prints faint message and sets HP to 0
        public void Faint()
        {
            Console.WriteLine(name + " fainted!");
            currentHP = 0;
        }

        //prints faint message and sets HP to 0
        public void GiveXP(int amount)
        {
            Console.WriteLine(name + " gained " + amount + " XP!");
            Thread.Sleep(2000);
            xp += amount;

            while(xp >= xpRequiredForLevel)
            {
                LevelUP();
            }
        }

        //increases this pokemons level by 1
        //reduces xp by amount required
        private void LevelUP()
        {
            if (level >= 100)
            {
                xp = 0;
                return;
            }

            xp = Math.Max(0, xp - xpRequiredForLevel);

            level += 1;
            Console.WriteLine(name + " grew to level " + level + "!");
            Thread.Sleep(2000);

            //evolve flag can only be set on level up (prevents pokemon from evolving on catch)
            if (level >= pokemonData.evolvesAt && pokemonData.evolvesInto != -1)
            {
                evolve = true;
            }

            //check for new moves to learn with UI
            CheckLearn(level, true);

            xpRequiredForLevel = level * level * 5;
            CalculateStats();
        }

        //checks the evolve flag of this pokemon and evolves them if needed
        public void CheckEvolve()
        {
            if(evolve)
            {
                Console.Clear();
                string oldName = name;
                Console.WriteLine("What?");
                Console.WriteLine(oldName + " is evolving!");
                Thread.Sleep(1500);
                Console.Write("Dun Da ");
                Thread.Sleep(1000);
                Console.Write("dun da ");
                Thread.Sleep(1000);
                Console.Write("dun daaa! \n");
                Thread.Sleep(2000);
                //evolve
                pokemonData = Global.pokeDex[pokemonData.evolvesInto];
                Console.WriteLine("Congratulations! Your {0} evolved into a {1}!", oldName, name);
                Thread.Sleep(2500);
                Console.Clear();
            }
        }
    }
}