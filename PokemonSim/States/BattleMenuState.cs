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
            Console.Clear();
            battleState.DrawBattlefield();

            int choose = Utils.GetChoice("Fight", "Pokemon", "Throw Pokeball", "Run");
            switch (choose)
            {
                case 0:
                    //Fight
                    Global.stateStack.Push(new BattleMoveSelectState(battleState));
                    break;

                case 1:
                    Global.stateStack.Push(new BattleViewPartyState(battleState));
                    break;

                case 2:
                    //Trainer battle check
                    if (battleState.trainerBattle)
                    {
                        Console.WriteLine("You can't catch a trainer's POKeMON!");
                    }
                    else
                    {
                        //enemy attacks if catch fails
                        if (!AttemptCatch())
                            Global.stateStack.Push(new BattleAttackState(battleState, battleState.enemy.party[0], Global.player.party[0]));
                    }
                    Thread.Sleep(2500);
                    break;

                case 3:
                    //Run
                    //Trainer battle check
                    if (battleState.trainerBattle)
                    {
                        Console.WriteLine("You can't run from a trainer battle!");
                    }
                    else
                    {
                        //enemy attacks if run fails
                        if (!AttemptRun())
                            Global.stateStack.Push(new BattleAttackState(battleState, battleState.enemy.party[0], Global.player.party[0]));
                    }
                    Thread.Sleep(2500);
                    break;
            }
        }

        //Run the run formula to see if run is successful or not
        private bool AttemptRun()
        {
            //pop menu state
            Global.stateStack.Pop();

            //run check
            Random rng = new Random();
            double runOdds = rng.Next(0, 255);
            double oddsEscape = ((Global.player.party[0].effectiveSpeed * 128 / battleState.enemy.party[0].effectiveSpeed) + 30) % 256;
            if (runOdds <= oddsEscape)
            {
                Console.WriteLine("Got away safely!");

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

        //check for successful catch or not
        private bool AttemptCatch()
        {
            //pop menu state
            Global.stateStack.Pop();

            //random with a randomized seed
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            
            //33% catch chance on a full health pokemon
            double catchRate = (3 * battleState.enemy.party[0].maxHP - 2 * battleState.enemy.party[0].currentHP) / (3 * battleState.enemy.party[0].maxHP);
            double catchRoll = rng.NextDouble();

            //Amount of shakes (visual only)
            int numShakes = 0;
            if (catchRoll <= catchRate) numShakes = 3;
            else
            {
                numShakes = rng.Next(1, 4);
            }
            while(numShakes > 0)
            {
                Console.WriteLine("*SHAKE*");
                Thread.Sleep(1500);
                numShakes--;
            }

            //catch or break
            if (catchRoll <= catchRate)
            {
                //pokemon caught
                Console.WriteLine("Gotcha!");
                Console.WriteLine(battleState.enemy.party[0].name + " was caught!");
                Global.player.AddToParty(battleState.enemy.party[0]);

                //pop battle state
                Global.stateStack.Pop();

                return true;
            }
            else
            {
                //pokemon escaped
                Console.WriteLine("Argh!");
                Console.WriteLine(battleState.enemy.party[0].name + " broke free!");
                return false;
            }
        }
    }
}
