using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGunSystem : MonoBehaviour
{

    //Bullet
    public GameObject bullet;

    //Bullet Force
    public float BulletForce, upwardForce;

    //Gun Stats
    public float timeBetweenShooting, spread, reloadTime, timeBetween;
    public int magazineSize, bulletPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //bool
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
