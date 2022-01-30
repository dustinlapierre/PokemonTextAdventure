namespace PokemonSim
{
    public class MenuState : State
    {
        public override void Update()
        {
            //show menu options
            Console.Clear();
            int choice = Utils.GetChoice("Pokemon", "Close Menu");
            switch(choice)
            {
                case 0:
                    Global.stateStack.Push(new ViewPartyState());
                    break;
                case 1:
                    Global.stateStack.Pop();
                    break;
            }
        }
    }
}
