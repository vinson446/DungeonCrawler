﻿using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);

    }

    public virtual void Interact()
    {

    }

}
