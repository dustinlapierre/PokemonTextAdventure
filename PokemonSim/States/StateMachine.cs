namespace PokemonSim
{
    //state machine implementation using a stack
    public class StateMachine
    {
        public Stack<State> states = new Stack<State>();
        public void Update()
        {
            //call update method of the top state in the stack
            states.Peek().Update();
        }
        public void Push(State state)
        {
            //push state onto stack and trigger enter function
            states.Push(state);
            state.Enter();
        }
        public void Pop()
        {
            //remove top of stack and trigger state exit
            states.Peek().Exit();
            states.Pop();
        }
    }
}
