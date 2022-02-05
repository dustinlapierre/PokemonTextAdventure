namespace PokemonSim
{
    public class PlayerTurnState : State
    {
        int playerAttackChoice = 0;
        private BattleState battleState;
        public PlayerTurnState(BattleState battle)
        {
            this.battleState = battle;
        }

        public override void Enter()
        {
            //get player attack choice before doing the actual turns
            playerAttackChoice = Utils.GetChoice(Global.player.party[0].GetAttackList());
        }

        //execute attack
        public override void Update()
        {
            //pop turn state
            Global.stateStack.Pop();

            //don't act if fainted
            if (Global.player.party[0].currentHP <= 0) return;

            //do attack
            Global.player.party[0].DoAttack(playerAttackChoice, battleState.enemy.party[0]);

            Thread.Sleep(2000);

            //death check
            battleState.FaintCheck();
        }
    }
}
