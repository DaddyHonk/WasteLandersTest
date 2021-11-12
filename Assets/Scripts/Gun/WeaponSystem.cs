using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using EZCameraShake;

public class WeaponSystem : MonoBehaviour
{
    [Header("Gun Stats")]
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    [Header("Debug")]
    public float Maxdistance = 10;


    [Header("bools")]
    bool shooting, readyToShoot, reloading;

    [Header("Reference")]
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    [Header("Graphics")]
    public GameObject muzzleFlash, Projectile /*bulletHoleGraphic*/;
    public float projectileSpeed = 40;
    [Header("")]
    public float magnitude = 0f;
    public float roughness = 0f;
    public float fadeInTime = 0f;
    public float fadeOutTime = 0f;
    public TextMeshProUGUI text;

    //private
    private Vector3 destination;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        //SetText
        text.SetText(bulletsLeft + " / " + magazineSize);
    }
    //weapon input
    private void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);

        }
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        float z = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, z);

        //RayCast

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
            destination = ray.GetPoint(1000);

        InstantiateProjectile(attackPoint);

        //------------------------------------------------------------------------------------------
        //if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        //{
        //    Debug.Log(rayHit.collider.name);

        //    if (rayHit.transform.tag == "Enemy")
        //    {
        //        EnemyHealth enemyHealthScript = rayHit.transform.GetComponent<EnemyHealth>();
        //        enemyHealthScript.TakeDamage(damage);
        //    }

        //}
        //------------------------------------------------------------------------------------------

        //ShakeCamera
        CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);

        ////Graphics
        // GameObject bulletInpact = Instantiate(bulletHoleGraphic, rayHit.point + new Vector3(0f, 0f, 0f), Quaternion.LookRotation(-rayHit.normal * 1)); 
        // bulletInpact.transform.Translate(rayHit.normal * .01f, Space.World);

         Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);

        Debug.DrawRay(transform.position, direction * Maxdistance, Color.red);
    }

    void InstantiateProjectile(Transform firepoint)
    {
        var projectileObj = Instantiate(Projectile, firepoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firepoint.position).normalized * projectileSpeed;
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
