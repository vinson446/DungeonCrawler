using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class Enemy : MonoBehaviour
{
    Player player;
    PlayerStats myStats;

    private void Start()
    {
        myStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        PlayerAttack playerattack = player.GetComponent<PlayerAttack>();
        if (playerattack != null)
        {
            playerattack.Attack(myStats);
        }

    }

}
