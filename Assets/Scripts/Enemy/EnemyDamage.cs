using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _delay;

    private Coroutine _coroutine;

    public void OnEnable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(BulletSpawn());
    }

    public IEnumerator BulletSpawn()
    {
        var wait = new WaitForSeconds(_delay);

        yield return wait;

        while (true)
        {
            Instantiate(_bullet, _firePoint.position, _firePoint.rotation);

            yield return wait;
        }
    }
}