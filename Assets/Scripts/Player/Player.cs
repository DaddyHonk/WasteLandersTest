using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 6;
    public float runspeed = 120;
    public float currentSpeed;
    public float scaleHight;
    


    Vector3 velocity;

    
    // Update is called once per frame
    void Update()
    {
// movement-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
      
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * currentSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runspeed;
        }
        else
        {
            currentSpeed = moveSpeed;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            gameObject.transform.localScale -= new Vector3(0, scaleHight, 0);
            scaleHight = Mathf.Clamp(scaleHight, .5f, 1);
        }


    }
}
