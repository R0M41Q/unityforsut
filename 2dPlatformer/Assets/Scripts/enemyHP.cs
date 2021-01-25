using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHP : MonoBehaviour
{
    [SerializeField] private float totalHP = 100f;

    private float currentHP;


    public float getHP()
    {
        return currentHP;
    }
    void Start()
    {
        currentHP = totalHP;
    }

    public void Heal(float healValue)
    {
        if (currentHP >= totalHP - healValue) currentHP = totalHP; else currentHP += healValue;
    }

    public void Damage(float damageValue)
    {
        if (currentHP <= damageValue)
        {
            Die();
        }
        else currentHP -= damageValue;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}