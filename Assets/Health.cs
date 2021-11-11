using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    // Start is called before the first frame update
    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public int GetHealth()
    {
        return health;
    }
}
