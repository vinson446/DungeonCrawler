using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    Animator animator;
   public bool damaged;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        damaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        isDamaged();

    }

   public void isDamaged()
    {
        if (damaged == true)
        {
            animator.Play("Dummy_Damaged");
        }
    }

}
