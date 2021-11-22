using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject myPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject obj = Instantiate(myPrefab) as GameObject;

            obj.transform.parent = transform;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(myPrefab);
    }

}
