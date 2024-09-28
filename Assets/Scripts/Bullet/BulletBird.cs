using UnityEngine;

public class BulletBird : Bullet
{
    [SerializeField] private int _damage = 10;

    private BirdBulletFactory _factory;

    public void SetFactory(BirdBulletFactory factory)
    {
        _factory = factory;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeHit(_damage);
            _factory.ReleaseObject(this);
        }

        if (collision.TryGetComponent<Ground>(out Ground ground))
        {
            _factory.ReleaseObject(this);
        }
    }
}