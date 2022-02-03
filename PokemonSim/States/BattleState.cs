namespace PokemonSim
{
    public class BattleState : State
    {
        public override void Update()
        {
            //show menu options
            Console.Clear();
            Console.WriteLine("A wild Dialga appeared! ...but sadly the battle state isn't yet implemented.");
            Thread.Sleep(2500);
            Global.stateStack.Pop();
        }
    }
}
