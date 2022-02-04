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
    }
}
