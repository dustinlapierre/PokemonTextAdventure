namespace PokemonSim
{
    //Attacks as a Strategy Pattern, execute can be overloaded for unique effects
    public abstract class Attack
    {
        public string attackName { get; set; } = "ATTACK";
        public PokemonType attackType { get; set; }
        public int basePower { get; set; }
        public virtual void Execute(Pokemon attacker, Pokemon target)
        {
            //base damage
            double damage = (2 * attacker.level / 5 + 2) * basePower * attacker.effectiveAttack / target.effectiveDefense / 50 + 2;
            //type effectiveness
            double damageMod = 1;
            foreach(PokemonType type in target.type)
            {
                damageMod *= PokemonTypeUtils.GetTypeDamageModifier(attackType, type);
            }
            //STAB
            double STAB = 0;
            if (attacker.type.Contains(attackType)) STAB = 0.1;
            //final calc
            damage *= (damageMod+STAB);
            //deal damage
            target.currentHP -= damage;

            //printout
            Console.WriteLine(attacker.name + " used " + attackName + "!");
            Thread.Sleep(1000);

            if(damageMod > 1)
                Console.WriteLine("ITS SUPER EFFECTIVE!");
            else if (damageMod < 1)
                Console.WriteLine("ITS NOT VERY EFFECTIVE!");

            Console.WriteLine();
            target.DrawHealthBar(20);
            Console.WriteLine();
        }
    }
}
