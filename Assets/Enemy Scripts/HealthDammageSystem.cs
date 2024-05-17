using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDammageSystem : MonoBehaviour
{
    private float health;
    private float maxHealth;

    public void SetMaxHealth(float maxHealth)
    {
        maxHealth = this.maxHealth;
    }
    public float Heal(float healAmount)
    {
        health += healAmount;
        return health;
    }
    public float DammageHealth(float dammage)
    {
        health -= dammage;
        return health;
    }

}
