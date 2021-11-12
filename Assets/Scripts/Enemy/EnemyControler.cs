using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public int health;
    public GameObject EnemyDeath;


    public float EnemyRange = 10f;

    public Rigidbody theRB;
    public float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, MouseLook.instance.transform.position) < EnemyRange)
        {
            Vector3 playerDirection = MouseLook.instance.transform.position - transform.position;

            theRB.velocity = playerDirection.normalized * MoveSpeed;

        }
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(EnemyDeath, transform.position, transform.rotation);
        }
    }
}
