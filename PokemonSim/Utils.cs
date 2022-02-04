namespace PokemonSim
{
    public static class Utils
    {
        //pass in a list of options as strings
        //returns the choice made as an int or 0 if an empty list is passed
        public static int GetChoice(params string[] optionList)
        {
            //clear buffer before reading input
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false); // true = hide input
            }

            //guard clause
            if (optionList.Length == 0) return 0;

            //show choices to user
            for (int i = 0; i < optionList.Length; i++)
            {
                Console.WriteLine((i+1) + ": " + optionList[i]);
            }

            int choice = -1;
            while (!Enumerable.Range(1, optionList.Length).Contains(choice))
            {   
                Console.Write("Choice: ");
                choice = GetInt();
                ClearLastConsoleLine();
            }
            //Show final choice result
            Console.WriteLine("Choice: " + choice);

            return choice-1;
        }

        //Gets int from user, returns -1 on invalid input
        public static int GetInt()
        {
            int integer = 0;
            if (!int.TryParse(Console.ReadLine(), out integer))
            {
                return -1;
            }

            return integer;
        }

        //removes the last line typed from the console
        public static void ClearLastConsoleLine()
        {
            int lastLineCursor = Console.CursorTop-1;
            Console.SetCursorPosition(0, lastLineCursor);
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");
            Console.SetCursorPosition(0, lastLineCursor);
        }
    }
}
