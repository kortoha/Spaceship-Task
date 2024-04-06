using System;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public delegate void DamageTaken(int damageCount);

    public event DamageTaken OnDamageTaken;

    private int _damageCount = 0;

    private bool _isInvincible = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isInvincible)
        {
            _isInvincible = true;
            OnDamageTaken?.Invoke(_damageCount);
            _damageCount++;
            Invoke("NotInvincible", 1);
            Analytics.Instance?.LogCollisionEvent();
        }
    }

    private void NotInvincible()
    {
        _isInvincible = false;
    }
}
