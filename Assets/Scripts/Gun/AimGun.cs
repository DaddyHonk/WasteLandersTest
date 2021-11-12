using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimGun : MonoBehaviour
{
    //public float aimSpeed = 10f;

    public Vector3 aimDownSights;
    //
    public Vector3 hipFire;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, aimDownSights, 10 * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, hipFire, 10 * Time.deltaTime);
        }
    }
}
