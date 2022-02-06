namespace PokemonSim
{
    public class BattleState : State
    {
        public Trainer enemy;
        public bool trainerBattle;
        public int reward;

        public BattleState(Trainer enemy, bool trainerBattle = false, int reward = 0)
        {
            this.enemy = enemy;
            this.trainerBattle = trainerBattle;
            this.reward = reward;
        }

        public override void Enter()
        {
            Console.Clear();

            if (trainerBattle)
            {
                //trainer battle intro
                Console.WriteLine(enemy.name + " would like to battle!");
                Thread.Sleep(1000);
                Console.WriteLine(enemy.name + " threw out " + enemy.party[0].name + "!");
            }
            else
            {
                //wild pokemon intro
                Console.WriteLine("A wild " + enemy.party[0].name + " appeared!");
            }

            Thread.Sleep(1500);
            Console.WriteLine("Go " + Global.player.party[0].name + "!");
            Thread.Sleep(2500);
        }

        public override void Update()
        {
            Console.Clear();
            DrawBattlefield();

            if (LossCheck(enemy))
            {
                if (trainerBattle)
                {
                    Console.WriteLine(Global.player.name.ToUpper() + " defeated " + enemy.name + "!");
                    Console.WriteLine(enemy.name + " dropped " + reward + "$!");
                    Global.player.money += reward;
                    enemy.Defeated();

                    Utils.GetChoice("Continue...");
                }
                //pop battle state
                Global.stateStack.Pop();
                return;
            }

            //loss check
            if (LossCheck(Global.player))
            {
                //pop battle state
                Global.stateStack.Pop();
                Global.player.Defeated();
                return;
            }

            //forced swap check

            //pass reference to this battle into the menu
            Global.stateStack.Push(new BattleMenuState(this));
        }

        //Draws both pokemon in battle and their data
        public void DrawBattlefield()
        {
            //opponent active pokemon
            Console.WriteLine();
            enemy.party[0].DrawHealthBar(20);

            //space
            Console.WriteLine();
            Console.WriteLine();

            //player pokemon
            Global.player.party[0].DrawHealthBar(20);
            Console.WriteLine();
        }

        //Check if either combatant has fainted
        public bool FaintCheck()
        {
            if (Global.player.party[0].currentHP <= 0)
            {
                Global.player.party[0].Faint();
                Thread.Sleep(2000);
                return true;
            }

            if (enemy.party[0].currentHP <= 0)
            {
                enemy.party[0].Faint();
                Thread.Sleep(2000);

                //grant xp
                Global.player.party[0].GiveXP((int) (enemy.party[0].maxHP * enemy.party[0].level));
                Thread.Sleep(2000);
                return true;
            }
            return false;
        }

        //check if trainer is out of pokemon
        public bool LossCheck(Trainer t)
        {
            foreach (Pokemon p in t.party)
            {
                if (p != null && p.currentHP > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
