using UnityEngine;

public class JumpState : State
{
    private float _tapForce;
    private float _speed;
    private float _rotationSpeed;
    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Vector3 _startPosition;
    private float _maxRotationZ;
    private float _minRotationZ;

    public JumpState(BirdController controller, float tapForce, float speed, float rotationSpeed, Rigidbody2D rigidbody2D, Quaternion maxRotation, Quaternion minRotation, Vector3 startPosition, float maxRotationZ, float minRotationZ) : base(controller)
    {
        _tapForce = tapForce;
        _speed = speed;
        _rotationSpeed = rotationSpeed;
        _rigidbody2D = rigidbody2D;
        _maxRotation = maxRotation;
        _minRotation = minRotation;
        _startPosition = startPosition;
        _maxRotationZ = maxRotationZ;
        _minRotationZ = minRotationZ;
    }

    public override void Enter()
    {
        base.Enter();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
        Controller.transform.rotation = _maxRotation;
    }

    public override void Update()
    {
        base.Update();

        Controller.transform.rotation = Quaternion.Lerp(Controller.transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}