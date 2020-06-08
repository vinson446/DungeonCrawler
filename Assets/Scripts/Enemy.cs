using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class Enemy : Interactable
{
    Player player;
    PlayerStats myStats;

    private void Start()
    {
        myStats = GetComponent<PlayerStats>();
    }

    public override void Interact()
    {
        base.Interact();
        PlayerAttack playerattack = player.GetComponent<PlayerAttack>();
        if(playerattack != null)
        {
            playerattack.Attack(myStats);
        }

    }
}
