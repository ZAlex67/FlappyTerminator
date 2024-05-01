using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Vector3 _value;
    [SerializeField] private int _count;
    [SerializeField] private float _delay;
    [SerializeField] private float _start;
    [SerializeField] private float _newWave;

    private Coroutine _coroutine;

    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds waitStart = new WaitForSeconds(_start);
        WaitForSeconds waitDelay = new WaitForSeconds(_start);
        WaitForSeconds waitNewWave = new WaitForSeconds(_start);

        yield return waitStart;

        while (true)
        {
            for (int i = 0; i < _count; i++)
            {
                Vector3 position = new Vector3(transform.position.x, Random.Range(-_value.y, _value.y), _value.z);

                Instantiate(_enemy, position, Quaternion.identity);

                yield return waitDelay;
            }

            yield return waitNewWave;
        }
    }
}