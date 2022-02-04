namespace PokemonSim
{
    public class BattleMenuState : State
    {
        private BattleState battleState;
        public BattleMenuState(BattleState battle)
        {
            this.battleState = battle;
        }
    }
}
