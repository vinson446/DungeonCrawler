using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform move;

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * 1;
        move.Translate(moveX,0,0);
    }


}
