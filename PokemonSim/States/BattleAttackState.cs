namespace PokemonSim
{
    public class BattleAttackState : State
    {
        int attackChoice;
        Pokemon attacker;
        Pokemon defender;
        private BattleState battleState;
        public BattleAttackState(BattleState battle, Pokemon attacker, Pokemon defender, int attackChoice = -1)
        {
            this.battleState = battle;
            this.attacker = attacker;
            this.defender = defender;
            //if no move choice was entered on call use AI
            if (attackChoice == -1)
                this.attackChoice = AIMoveSelection();
            else
                this.attackChoice = attackChoice;
        }

        //execute attack
        public override void Update()
        {
            Console.Clear();

            //pop turn state
            Global.stateStack.Pop();

            //don't act if fainted
            if (attacker.currentHP <= 0) return;

            //do attack
            attacker.DoAttack(attackChoice, defender);

            Thread.Sleep(2000);
        }

        private int AIMoveSelection()
        {
            //organizes moves based on effectiveness
            PriorityQueue<int, double> moveDesire = new PriorityQueue<int, double>();
            for (int i = 0;i<attacker.attackList.Length;i++)
            {
                Attack atk = attacker.attackList[i];
                if (atk == null) continue;
                
                //calculate move effectiveness
                double effectiveness = 1;
                foreach(PokemonType type in defender.type)
                {
                    effectiveness *= PokemonTypeUtils.GetTypeDamageModifier(atk.attackType, type);
                }
                effectiveness *= atk.basePower;

                //enqueue based on negative effectiveness (lowest number = higher priority)
                moveDesire.Enqueue(i, -effectiveness);
            }

            //choose the most effective move
            return moveDesire.Dequeue();
        }
    }
}
