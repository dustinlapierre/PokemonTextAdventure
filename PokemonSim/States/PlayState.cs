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

            Console.Write("1: ");
            Pokemon charmander = new Pokemon(new Charmander(), 5);
            charmander.showDescription();
            Console.Write("2: ");
            Pokemon squirtle = new Pokemon(new Squirtle(), 5);
            squirtle.showDescription();
            Console.Write("3: ");
            Pokemon bulbasaur = new Pokemon(new Bulbasaur(), 5);
            bulbasaur.showDescription();

            Pokemon[] starters = {charmander, squirtle, bulbasaur};

            int choice = 0;
            bool choosing = true;
            while(choosing)
            {
                //replace with a get choice function!
                Console.WriteLine("Starter Choice: ");
                choice = Int32.Parse(Console.ReadLine());
                if(choice >= 1 && choice <= 3)
                {
                    choosing = false;
                }
                else
                {
                    Console.WriteLine("Invalid Choice!");
                }
            }
            Console.WriteLine(starters[choice-1].name + " joined your party!");
            Thread.Sleep(3000);
        }
        public override void Update()
        {
            //base play options
            Console.Clear();
            Console.WriteLine("Current Location: " + Global.location.name);
            Console.ReadLine();
        }
    }
}
