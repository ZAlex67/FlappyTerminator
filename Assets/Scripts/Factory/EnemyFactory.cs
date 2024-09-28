using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ScoreCounter))]
public class EnemyFactory : SpawnerGeneric<Enemy>
{
    [SerializeField] private Vector3 _value;
    [SerializeField] private int _count;
    [SerializeField] private float _delay;
    [SerializeField] private float _start;
    [SerializeField] private float _newWave;

    private ScoreCounter _scoreCounter;
    private Coroutine _coroutine;

    private void Awake()
    {
        CreatePool();
        _scoreCounter = GetComponent<ScoreCounter>();
    }

    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Spawn());
    }

    protected override void ActionOnGet(Enemy enemy)
    {
        Vector3 position = new Vector3(transform.position.x, Random.Range(-_value.y, _value.y), _value.z);

        enemy.SetScoreCounter(_scoreCounter);
        enemy.SetEnemyFactory(this);
        enemy.transform.position = position;
        enemy.gameObject.SetActive(true);
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds waitStart = new WaitForSeconds(_start);
        WaitForSeconds waitDelay = new WaitForSeconds(_start);
        WaitForSeconds waitNewWave = new WaitForSeconds(_start);

        yield return waitStart;

        while (enabled)
        {
            for (int i = 0; i < _count; i++)
            {
                GetPrefab();

                yield return waitDelay;
            }

            yield return waitNewWave;
        }
    }
}