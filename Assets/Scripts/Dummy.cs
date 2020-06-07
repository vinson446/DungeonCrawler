using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    [SerializeField] GameObject slash;
    Animator animator;
    bool damaged;
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

    void isDamaged()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.Play("Dummy_Damaged");
            slash.SetActive(true);
        }
    }

}
