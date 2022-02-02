namespace PokemonSim
{
    public class ViewPartyState : State
    {
        public override void Update()
        {
            //show party printout
            Console.Clear();
            Global.player.showParty();
            int choice = Utils.GetChoice("Close");
            Global.stateStack.Pop();
        }
    }
}
