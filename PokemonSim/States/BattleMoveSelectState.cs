namespace PokemonSim
{
    public class BattleMoveSelectState : State
    {
        private BattleState battleState;
        public BattleMoveSelectState(BattleState battle)
        {
            this.battleState = battle;
        }

        public override void Update()
        {
            //load attack list and append back option
            List<string> options = Global.player.party[0].GetAttackList();
            options.Add("Back");

            //get player choice
            int choose = Utils.GetChoice(options.ToArray());
            if(choose == options.Count-1)
            {
                //cancel attack choice
                Global.stateStack.Pop();
            }
            else
            {
                //attack chosen do player attack

                //pop attack choice
                Global.stateStack.Pop();
                //pop menu state
                Global.stateStack.Pop();

                if (Global.player.party[0].effectiveSpeed >= battleState.enemy.party[0].effectiveSpeed)
                {
                    //player goes first
                    Global.stateStack.Push(new BattleAttackState(battleState, battleState.enemy.party[0], Global.player.party[0]));
                    Global.stateStack.Push(new BattleAttackState(battleState, Global.player.party[0], battleState.enemy.party[0], choose));
                }
                else
                {
                    //enemy goes first
                    Global.stateStack.Push(new BattleAttackState(battleState, Global.player.party[0], battleState.enemy.party[0], choose));
                    Global.stateStack.Push(new BattleAttackState(battleState, battleState.enemy.party[0], Global.player.party[0]));
                }
            }
        }
    }
}
