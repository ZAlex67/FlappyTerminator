using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _health;
    [SerializeField, Range(0, 100)] private float _maxHealth;

    public void TakeHit(float damage)
    {
        if (damage >= 0)
            _health = Mathf.Clamp(_health -= damage, 0, _maxHealth);

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}