using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private InputBird _input;

    private void OnEnable()
    {
        _input.Shooting += OnShootAction;
    }

    private void OnDisable()
    {
        _input.Shooting -= OnShootAction;
    }

    private void OnShootAction()
    {
        Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
    }
}