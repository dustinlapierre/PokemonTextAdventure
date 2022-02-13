namespace PokemonSim
{
    public class ViewPartyState : State
    {
        public override void Update()
        {
            //show party printout
            Console.Clear();
            Global.player.ShowParty();
            int choice = Utils.GetChoice("Swap", "Back");
            switch(choice)
            {
                case 0:
                    Global.player.SwapPartyPokemon();
                    break;
                case 1:
                    Global.stateStack.Pop();
                    break;
            }
        }
    }
}
