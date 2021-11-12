using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunGenerator : MonoBehaviour
{
    [SerializeField] Transform gunParent;
    [SerializeField] GameObject Sparticle;

    public List<GameObject> bodyParts;
    public List<GameObject> barrelParts;
    public List<GameObject> scopeParts;
    public List<GameObject> magazineParts;
    public List<GameObject> stockParts;

    GameObject prevWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateWeapon();

        }
    }

    void GenerateWeapon()
    {
        //GameObject.Instantiate(/*Sparticle*/ gunParent.transform.position, gunParent.transform.rotation);

        if (prevWeapon != null)
        {
            Destroy(prevWeapon);
        }
        //if (Sparticle != null)
        //{
        //    Destroy(Sparticle);
        //}


        GameObject randomBody = GetRandomPart(bodyParts);
        GameObject insBody = Instantiate(randomBody, gunParent.transform.position, gunParent.transform.rotation, gunParent.transform );
        WeaponBody wpnBody = insBody.GetComponent<WeaponBody>();

        SpawnWeaponPart(barrelParts, wpnBody.barrelSocket);
        SpawnWeaponPart(scopeParts, wpnBody.scopeSocket);
        SpawnWeaponPart(magazineParts, wpnBody.magazineSocket);
        SpawnWeaponPart(stockParts, wpnBody.stockSocket);

        prevWeapon = insBody;
    }

    void SpawnWeaponPart(List<GameObject> parts, Transform socket)
    {
        GameObject randomPart = GetRandomPart(parts);
        GameObject insPart = Instantiate(randomPart, socket.transform.position, socket.transform.rotation);
        insPart.transform.parent = socket;
    }

    GameObject GetRandomPart(List<GameObject> partList)
    {
        int randomNumber = Random.Range(0, partList.Count);
        return partList[randomNumber];
    }
}


        //GameObject randomBarrel = GetRandomPart(barrelParts);
        //GameObject insBarrel = Instantiate(randomBarrel, wpnBody.barrelSocket.position, Quaternion.identity);
        //insBarrel.transform.parent = wpnBody.barrelSocket;

        //GameObject randomScope = GetRandomPart(scopeParts);
        //Instantiate(randomScope, Vector3.zero, Quaternion.identity);

        //GameObject randomMagazine = GetRandomPart(magazineParts);
        //Instantiate(randomMagazine, Vector3.zero, Quaternion.identity);

        //GameObject randomStock = GetRandomPart(stockParts);
        //Instantiate(randomStock, Vector3.zero, Quaternion.identity);