//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GunController : MonoBehaviour
//{
//    public Transform weaponHold;
//    public WeaponSystem StartingGun;
//    public WeaponSystem equippedGun;

//    void Start()
//    {
//        if (StartingGun != null)
//        {
//            EquipGun(StartingGun);
//        }      
//    }

//    public void EquipGun(WeaponSystem gunToEquip)
//    {
//        if (equippedGun != null)
//        { 
//            Destroy(equippedGun.gameObject);
//	    }
//        equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as WeaponSystem;
//        equippedGun.transform.parent = weaponHold;
//    }

//    public void OnTriggerHold()
//    {
//        if (equippedGun != null)
//        {
//            equippedGun.OnTriggerHold();
//        }
//    }

//    public void OnTriggerRelease()
//    {
//        if (equippedGun != null)
//        {
//            equippedGun.OnTriggerRelease();
//        }
//    }
//}
