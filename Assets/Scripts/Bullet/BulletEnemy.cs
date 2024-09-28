using UnityEngine;

public class BulletEnemy : Bullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground))
        {
            Destroy(gameObject);
        }
    }
}