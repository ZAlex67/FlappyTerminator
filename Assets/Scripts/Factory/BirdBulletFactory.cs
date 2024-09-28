using UnityEngine;

public class BirdBulletFactory : SpawnerGeneric<BulletBird>
{
    [SerializeField] private Transform _firePoint;

    private void Awake()
    {
        CreatePool();
    }

    protected override void ActionOnGet(BulletBird bullet)
    {
        bullet.SetFactory(this);
        bullet.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
        bullet.gameObject.SetActive(true);
    }
}