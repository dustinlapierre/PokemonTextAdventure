namespace PokemonSim
{
    public class PlayerIdleState : State
    {
        public override void Update()
        {
            //what can the player do in this location
            string[] playerOptions = { "Open Menu" };
            string[] choices = Global.location.options.ToArray().Concat(playerOptions).ToArray();
            int choice = Utils.GetChoice(choices);
        }
    }
}
