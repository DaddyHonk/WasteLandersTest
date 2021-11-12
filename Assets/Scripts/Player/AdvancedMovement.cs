using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedMovement : MonoBehaviour
{
    CharacterController playerCol;
    float originalHeight;
    public float reducedHeight;

    // Start is called before the first frame update
    void Start()
    {
        playerCol = GetComponent<CharacterController>();
        originalHeight = playerCol.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            Crouch();
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            GoUp();
    }

    void Crouch()
    {
        playerCol.height = reducedHeight;
    }

    void GoUp()
    {
        playerCol.height = originalHeight;
    }
}
