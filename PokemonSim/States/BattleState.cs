namespace PokemonSim
{
    public class BattleState : State
    {
        private Trainer enemy;
        private bool trainerBattle;
        public BattleState(Trainer enemy, bool trainerBattle = false)
        {
            this.enemy = enemy;
            this.trainerBattle = trainerBattle;
        }
        public override void Enter()
        {
            Console.Clear();

            //Appropriate start message
            if (trainerBattle)
                Console.WriteLine(enemy.name + " would like to battle!");
            else
                Console.WriteLine("A wild " + enemy.party[0].name + " appeared!");

            Console.WriteLine("Go " + Global.player.party[0].name + "!");
            Thread.Sleep(2500);
        }
        public override void Update()
        {
            Console.Clear();

            //draw battle arena
            //opponent active pokemon
            Console.WriteLine();
            Console.WriteLine(enemy.party[0].name + " LV. " + enemy.party[0].level);
            enemy.party[0].DrawHealthBar(20);

            //space
            Console.WriteLine();
            Console.WriteLine();

            //player pokemon
            Console.WriteLine(Global.player.party[0].name + " LV. " + Global.player.party[0].level);
            Global.player.party[0].DrawHealthBar(20);
            Console.WriteLine();

            Console.WriteLine("Battle not implemented yet.");
            Console.Read();
            Global.stateStack.Pop();
        }
    }
}
