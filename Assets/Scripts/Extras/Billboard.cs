using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void LateUpdate()
    {
        transform.LookAt(transform.position + MouseLook.instance.transform.rotation * Vector3.forward,
             MouseLook.instance.transform.rotation * Vector3.up);
    }
}

   