namespace PokemonSim
{
    public class PlayState : State
    {
        public override void Enter()
        {
            //Game start
            Console.WriteLine("Welcome to the world of Pokemon!");

            //Choose player name
            Console.WriteLine("What's your name?");
            string userName = Console.ReadLine();
            userName = (userName != null && userName.Length > 0) ? userName.ToUpper() : "RED";
            Global.player = new Player(userName);

            //Choose starter
            Console.WriteLine("Hello " + userName + "! Let's get you started with your first Pokemon!");

            //User selects a starter
            Pokemon charmander = new Pokemon(new Charmander(), 5);
            Pokemon squirtle = new Pokemon(new Squirtle(), 5);
            Pokemon bulbasaur = new Pokemon(new Bulbasaur(), 5);

            Pokemon[] starters = {charmander, squirtle, bulbasaur};

            int choice = Utils.GetChoice(charmander.GetDescription(), squirtle.GetDescription(), bulbasaur.GetDescription());
            Global.player.AddToParty(starters[choice]);

            Thread.Sleep(3000);
        }
        public override void Update()
        {
            //base play options
            Console.Clear();
            Console.WriteLine("Current Location: " + Global.location.name);
            Global.player.state.Update();
        }
    }
}
