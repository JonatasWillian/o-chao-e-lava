using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [Header("Damage")]
    public float damage = 6f;
    [Header("Life")]
    public float startLife = 10f;

    [Space]
    public Player player;
    public float reviveDuration = .5f;

    [Space]
    public bool destroyOnKill = false;
    [SerializeField] private float _currentLife;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        ResetLife();
    }

    public void ResetLife()
    {
        _currentLife = startLife;
    }

    protected virtual void Kill()
    {
        if (destroyOnKill)
            Destroy(gameObject, .1f);

        OnKill?.Invoke(this);
        Invoke(nameof(Revive), reviveDuration);
    }

    [NaughtyAttributes.Button]
    private void Revive()
    {
        ResetLife();
        player.Respawn();
    }

    [NaughtyAttributes.Button]
    public void Damage()
    {
        Damage(damage);
    }

    public void Damage(float f)
    {
        _currentLife -= f;

        if (_currentLife <= 0)
        {
            Kill();
        }

        OnDamage?.Invoke(this);
    }

    public void Damage(float damage, Vector3 dir)
    {
        Damage(damage);
    }
}
