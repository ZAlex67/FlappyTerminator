
public abstract class State
{
    protected BirdController Controller;

    protected State(BirdController controller)
    {
        Controller = controller;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}