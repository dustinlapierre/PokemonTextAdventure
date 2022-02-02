namespace PokemonSim
{
    //the player character, which doubles as the game controller
    public class Player
    {
        public Pokemon[] party = { null, null, null, null, null, null };
        public string name { get; set; }
        public int numBadges = 0;
        public int money = 0;
        public State state { get; set; } = new PlayerIdleState();
        //public List<Item> bag = new List<Item>();
        public Player(string name)
        {
            this.name = name;
        }

        //adds pokemon to first available slot in party
        //if no slots remain add pokemon to PC box
        public void AddToParty(Pokemon recruit)
        {
            for(int i = 0; i < party.Length; i++)
            {
                if(party[i] == null)
                {
                    party[i] = recruit;
                    Console.WriteLine(recruit.name + " joined your party!");
                    return;
                }
            }
            Console.WriteLine("Party is full, " + recruit.name + " will be sent to the PC instead!");
            //no slots left add to PC
        }

        //draws the players party onto the screen
        public void ShowParty()
        {
            foreach (Pokemon p in party)
            {
                if(p != null)
                {
                    //name and level
                    Console.Write("LV. {0} {1}", p.level, p.name);
                    //types
                    foreach(PokemonType type in p.type)
                    {
                        Console.Write(" " + type.ToString() + " ");
                    }
                    //status
                    Console.Write("| HP: {0}/{1}\n", p.currentHP, p.maxHP);
                }
                else
                {
                    Console.WriteLine("---");
                }
            }
        }

        //fully heals all pokemon in your party
        public void HealParty()
        {
            foreach (Pokemon p in party)
            {
                if (p != null)
                {
                    p.currentHP = p.maxHP;
                }
            }
        }
    }
}
