namespace PokemonSim
{
    public class PlayerIdleState : State
    {
        public override void Update()
        {
            //check if any members of party need to evolve
            foreach(Pokemon p in Global.player.party)
            {
                if(p != null) p.CheckEvolve();
            }

            //what can the player do in this location
            string[] playerOptions = { "Open Menu" };
            string[] choices = Global.location.options.ToArray().Concat(playerOptions).ToArray();
            int choice = Utils.GetChoice(choices);
            if(choice < Global.location.options.Count)
            {
                Global.location.Explore(choice);
            }
            else
            {
                //player chose to open menu
                Global.stateStack.Push(new MenuState());
            }
        }
    }
}
