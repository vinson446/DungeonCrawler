using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

   public void isDamaged()
    {
        animator.SetBool("Damaged", true);
        StartCoroutine(Reset());

    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Damaged", false);
    }

}
