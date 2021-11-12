using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBulletTest : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && hit.transform.tag == "Minion")
            {
                if (Vector3.Distance(this.transform.position, hit.point) <= atkRange)
                {
                    GameObject proj = Instantiate(bullet) as GameObject;
                    proj.transform.position = Vector3.MoveTowards(this.transform.position, target, atkSpd);
                }
            }
            else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, speed))
            {
                agent.destination = hit.point;
            }
        }
    }
}
