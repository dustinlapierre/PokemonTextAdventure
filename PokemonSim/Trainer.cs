namespace PokemonSim
{
    public class Trainer
    {
        public string name { get; set; } = "Oops";
        public Pokemon[] party = { null, null, null, null, null, null };

        //Can initialize party with the constructor if desired
        public Trainer(params Pokemon[] partyMembers)
        {
            for(int i = 0; i < partyMembers.Length; i++)
            {
                this.party[i] = partyMembers[i];
            }
        }

        public virtual void Defeated()
        {
            // base does nothing on defeat
        }

        public virtual void SwapActivePokemon(bool forcedSwap = true)
        {
            // base auto swaps to the next pokemon
            for(int i = 1; i < party.Length; i++)
            {
                if (party[i] == null) return;

                if(party[i].currentHP > 0)
                {
                    //swap to active
                    (party[0], party[i]) = (party[i], party[0]);
                }
            }
        }
    }
}
