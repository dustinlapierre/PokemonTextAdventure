namespace PokemonSim
{
    public class BattleMenuState : State
    {
        private BattleState battleState;
        public BattleMenuState(BattleState battle)
        {
            this.battleState = battle;
        }
        public override void Update()
        {
            int choose = Utils.GetChoice("Fight", "Run"); //pokemon, items
            switch(choose)
            {
                case 0:
                    //Fight - for now both pokemon just do their first attack
                    Global.player.party[0].DoAttack(0, battleState.enemy.party[0]);
                    battleState.enemy.party[0].DoAttack(0, Global.player.party[0]);
                    //pop menu state
                    Global.stateStack.Pop();
                    break;
                case 1:
                    //Run
                    //Trainer battle check
                    if (battleState.trainerBattle)
                    {
                        Console.WriteLine("You can't run from a trainer battle!");
                    }
                    else
                    {
                        AttemptRun();
                    }
                    break;
            }
            Thread.Sleep(2500);
        }

        //Run the run formula to see if run is successful or not
        private void AttemptRun()
        {
            Random rng = new Random();
            double runOdds = rng.Next(0, 255);
            double oddsEscape = ((Global.player.party[0].effectiveSpeed * 128 / battleState.enemy.party[0].effectiveSpeed) + 30) % 256;
            if (runOdds <= oddsEscape)
            {
                Console.WriteLine("Got away safely!");

                //pop menu state
                Global.stateStack.Pop();

                //pop battle state
                Global.stateStack.Pop();
            }
            else
            {
                Console.WriteLine("Can't escape!");
                //pop menu state
                Global.stateStack.Pop();
            }
        }
    }
}
