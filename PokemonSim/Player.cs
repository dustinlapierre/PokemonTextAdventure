namespace PokemonSim
{
    //the player character, which doubles as the game controller
    public class Player : Trainer
    {
        public int numBadges = 0;
        public int money = 0;
        public State state { get; set; } = new PlayerIdleState();
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
            //no slots left add to PC (not implemented)
        }

        //draws the players party onto the screen
        public void ShowParty()
        {
            foreach (Pokemon p in party)
            {
                if(p != null)
                {
                    //print pokemon in menu
                    Console.WriteLine(p.GetMenuText());
                }
                else
                {
                    //empty slot
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

        public override void Defeated()
        {
            //player has been defeated
            Console.WriteLine(name.ToUpper() + " is out of usable pokemon!");
            Thread.Sleep(2000);
            Console.WriteLine(name.ToUpper() + " blacked out...");
            money = money / 2;
            HealParty();
            Thread.Sleep(2500);
        }

        public override void SwapActivePokemon(bool forcedSwap = true)
        {
            //player chooses which pokemon to swap to in battle
            List<string> partyNames = new List<string>();
            foreach (Pokemon p in party)
            {
                if(p == null)
                {
                    partyNames.Add("---");
                }
                else
                {
                    partyNames.Add(p.GetMenuText());
                }
            }
            //allow player to cancel if the swap isn't forced
            if(!forcedSwap) partyNames.Add("Cancel");

            while (true)
            {
                Console.Clear();
                //prompt player to select pokemon
                Console.WriteLine("Choose a POKeMON: ");
                int choice = Utils.GetChoice(partyNames.ToArray());

                //check for cancel
                if (partyNames[choice] == "Cancel") break;

                if (choice == 0)
                {
                    Console.WriteLine("That POKeMON is already active!");
                    Thread.Sleep(2000);
                }
                else if(party[choice] == null)
                {
                    Console.WriteLine("That slot is empty!");
                    Thread.Sleep(2000);
                }
                else if(party[choice].currentHP <= 0)
                {
                    Console.WriteLine("That POKeMON isn't fit for battle!");
                    Thread.Sleep(2000);
                }
                else
                {
                    //valid selection was made, escape
                    (party[0], party[choice]) = (party[choice], party[0]);
                    Console.Clear();
                    Console.WriteLine("Go " + party[0].name + "!");
                    Thread.Sleep(2000);
                    break;
                }

            }
        }
        public void SwapPartyPokemon()
        {
            //player chooses two pokemon to swap
            Console.WriteLine("Type the numbers of the POKeMON you wish to swap separated by a space (Ex. Swap: 2 4)");
            Console.Write("Swap: ");

            //parse out both choices
            var choices = new List<int>();
            foreach (string s in Console.ReadLine().Split())
            {
                if (choices.Count >= 2) break;

                if (int.TryParse(s, out int number))
                {
                    if (number <= party.Length && number >= 1)
                        choices.Add(number-1);
                }
                else return;
            }
            if (choices.Count < 2) return;

            if (party[choices[0]] != null && party[choices[1]] != null)
            {
                (party[choices[0]], party[choices[1]]) = (party[choices[1]], party[choices[0]]);
            }
        }
    }
}
