using UnityEngine;

public class IdleState : State
{
    private Vector3 _startPosition;

    public IdleState(BirdController controller, Vector3 startPosition) : base(controller)
    {
        _startPosition = startPosition;
    }

    public override void Enter()
    {
        base.Enter();

        _startPosition = Controller.transform.position;
    }
}