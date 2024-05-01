using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _delay;

    private Coroutine _coroutine;

    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(BulletSpawn());
    }

    private IEnumerator BulletSpawn()
    {
        var wait = new WaitForSeconds(_delay);
        int count = 10;

        yield return wait;

        for (int i = 0; i < count; i++)
        {
            Instantiate(_bullet, _firePoint.position, _firePoint.rotation);

            yield return wait;
        }

        yield return null;
    }
}