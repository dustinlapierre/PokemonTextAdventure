namespace PokemonSim
{
    public class BattleMenuState : State
    {
        private BattleState battleState;
        public BattleMenuState(BattleState battle)
        {
            this.battleState = battle;
        }
        public override void Enter()
        {
            int choose = Utils.GetChoice("Fight", "Run"); //pokemon, items
            switch(choose)
            {
                case 0:
                    //Fight
                    if (Global.player.party[0].effectiveSpeed >= battleState.enemy.party[0].effectiveSpeed)
                    {
                        //player goes first
                        Global.stateStack.Push(new EnemyTurnState(battleState));
                        Global.stateStack.Push(new PlayerTurnState(battleState));
                    }
                    else
                    {
                        //enemy goes first
                        Global.stateStack.Push(new PlayerTurnState(battleState));
                        Global.stateStack.Push(new EnemyTurnState(battleState));
                    }
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
                        //enemy attacks if run fails
                        if(!AttemptRun())
                            Global.stateStack.Push(new EnemyTurnState(battleState));
                    }
                    Thread.Sleep(2500);
                    break;
            }
            Console.Clear();
        }

        public override void Update()
        {
            //pop menu state
            Global.stateStack.Pop();
        }

        //Run the run formula to see if run is successful or not
        private bool AttemptRun()
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

                return true;
            }
            else
            {
                Console.WriteLine("Can't escape!");
                return false;
            }
        }
    }
}
