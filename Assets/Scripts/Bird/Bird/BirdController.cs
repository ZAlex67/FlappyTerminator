using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private InputBird _input;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private StateMachine _stateMachine;
    private IdleState _idleState;
    private JumpState _jumpState;

    private void OnEnable()
    {
        _input.Jumping += OnJump;
    }

    private void OnDisable()
    {
        _input.Jumping -= OnJump;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _stateMachine = new StateMachine();
        _idleState = new IdleState(this, _startPosition);
        _jumpState = new JumpState(this, _tapForce, _speed, _rotationSpeed, _rigidbody2D, _maxRotation, _minRotation, _startPosition, _maxRotationZ, _minRotationZ);
        _stateMachine.Initialize(_idleState);
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody2D.velocity = Vector2.zero;
    }

    private void OnJump()
    {
        _stateMachine.ChangeState(_jumpState);
    }
}