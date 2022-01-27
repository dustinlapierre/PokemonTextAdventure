namespace PokemonSim
{
    //making this abstract rather than an interface because
    //not all states will need to implement all of them
    //so we now have the freedom to leave some out
    public abstract class State
    {
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
