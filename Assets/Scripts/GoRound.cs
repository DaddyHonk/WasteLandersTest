using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoRound : MonoBehaviour
{
   public float speed, lenght;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Cos(speed) * lenght, Mathf.Sin(speed) * lenght);

    }
}
