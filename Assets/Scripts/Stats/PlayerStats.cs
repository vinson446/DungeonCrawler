using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    Player player;

    public int Health = 100;
    public int currentHealth { get; private set; }


    public Stat damage;

    private void Awake()
    {
        currentHealth = Health;
        player = GetComponent<Player>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            player.dead = true;
        }

    }

    public void Die()
    {

    }
}
