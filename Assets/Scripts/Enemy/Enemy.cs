using UnityEngine;

[RequireComponent(typeof(EnemyDamage))]
public class Enemy : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _health;
    [SerializeField, Range(0, 100)] private float _maxHealth;
    [SerializeField] private Death _death;

    private EnemyFactory _enemyFactory;
    private ScoreCounter _scoreCounter;

    public void TakeHit(float damage)
    {
        if (damage >= 0)
            _health = Mathf.Clamp(_health -= damage, 0, _maxHealth);

        if (_health <= 0)
            Die();
    }

    public void SetScoreCounter(ScoreCounter scoreCounter)
    {
        _scoreCounter = scoreCounter;
    }

    public void SetEnemyFactory(EnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }

    private void Die()
    {
        _enemyFactory.ReleaseObject(this);
        _scoreCounter.Add();
        Instantiate(_death, transform.position, Quaternion.identity);
    }
}