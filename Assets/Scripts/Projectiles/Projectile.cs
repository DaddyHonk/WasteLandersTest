using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool collided;
    private void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player" && !collided)
        {
            collided = true;
            Destroy(gameObject);
        }
    }
}
