using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    public Transform playerCam;
    public float leftBoundary;
    public float rightBoundary;
    public float moveCamRightAmount;
    public float moveCamLeftAmount;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        // get player's position in relation to the screen
        Vector3 screenPos = Camera.main.WorldToScreenPoint(player.transform.position);

        // if player hits the left boundary, move cam left
        if (screenPos.x < 0 + leftBoundary)
            MoveCamLeft();
        // if player hits the right boundary, move cam right
        else if (screenPos.x > Screen.width - rightBoundary)
            MoveCamRight();
    }

    public void MoveCamRight()
    {
        playerCam.transform.localPosition += new Vector3(moveCamRightAmount, 0, 0);
    }

    public void MoveCamLeft()
    {
        playerCam.transform.localPosition -= new Vector3(moveCamLeftAmount, 0, 0);
    }
}
