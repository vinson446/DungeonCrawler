using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerAttack : MonoBehaviour
{
    PlayerStats myStats;

    private void Start()
    {
        myStats = GetComponent<PlayerStats>();

    }

    public void Attack(PlayerStats targetStats)
    {
        targetStats.TakeDamage(myStats.damage.GetValue());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dummy"))
        {
            other.GetComponent<Dummy>().isDamaged();
        }
    }

}
