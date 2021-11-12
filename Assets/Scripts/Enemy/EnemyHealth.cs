using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    public ParticleSystem DeathEffect;
    public float enemyHealth;
    public GameObject Player;

    public void TakeDamage(float TakeDamage)
    {
        enemyHealth -= TakeDamage;

        if (enemyHealth <= 0)
        {
            EnemyDead();
        }
    }

    public void EnemyDead()
    {
        //Player.transform.rotation
        //Quaternion.identity
        Instantiate(DeathEffect, transform.position, Quaternion.LookRotation(gameObject.transform.position - Player.transform.position));

        Destroy(gameObject);
    }
}
