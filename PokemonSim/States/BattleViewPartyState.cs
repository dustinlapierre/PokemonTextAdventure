namespace PokemonSim
{
    public class BattleViewPartyState : State
    {
        private BattleState battleState;
        public BattleViewPartyState(BattleState battle)
        {
            this.battleState = battle;
        }
        public override void Update()
        {
            //show party printout
            Console.Clear();
            Global.player.ShowParty();
            int choice = Utils.GetChoice("Swap", "Back");
            switch(choice)
            {
                case 0:
                    //current active pokemon
                    Pokemon current = Global.player.party[0];

                    //prompt for swap
                    Global.player.SwapActivePokemon(false);

                    if(current != Global.player.party[0])
                    {
                        //player chose to swap advance battle
                        Global.stateStack.Pop();
                        Global.stateStack.Push(new BattleAttackState(battleState, battleState.enemy.party[0], Global.player.party[0]));
                    }
                    break;
                case 1:
                    Global.stateStack.Pop();
                    break;
            }
        }
    }
}
