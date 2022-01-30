namespace PokemonSim
{
    public class ViewPartyState : State
    {
        public override void Update()
        {
            //show party printout
            Console.Clear();
            Global.player.showParty();
            Console.Read();
            Global.stateStack.Pop();
        }
    }
}
