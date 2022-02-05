namespace PokemonSim
{
    public class EnemyTurnState : State
    {
        int enemyAttackChoice = 0;
        private BattleState battleState;
        public EnemyTurnState(BattleState battle)
        {
            this.battleState = battle;
        }
        //execute attack
        public override void Update()
        {
            //pop turn state
            Global.stateStack.Pop();

            //don't act if fainted
            if (battleState.enemy.party[0].currentHP <= 0) return;

            //do attack
            battleState.enemy.party[0].DoAttack(enemyAttackChoice, Global.player.party[0]);

            Thread.Sleep(2000);

            //death check
            battleState.FaintCheck();
        }
    }
}
