using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    //Start location of bullets
    public Transform launchPosition;

    public float bulletSpeed = 20.0f;

    bool semiAuto = true;

    void fireBullet()
    {
        Rigidbody bullet = createBullet();
        bullet.velocity = transform.parent.forward * bulletSpeed;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check input manager to see if left mouse button is held (1 = right, 2 = middle)
        if (Input.GetMouseButtonDown(0))
        {
            //Makes weapon semi automatic
            if (semiAuto == true)
            {
                Invoke("fireBullet", 0f);
            }

            if (semiAuto == false)
            {            
                //(makes weapon fully automatic)
                //If fireBullet is not being invoked, call invoke repeating 
                if (!IsInvoking("fireBullet"))
                {
                    InvokeRepeating("fireBullet", 0f, 0.1f);
                }
            }
        }
        //Check if mouse button is released, cancel shooting
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("fireBullet");
        }
    }

    private Rigidbody createBullet()
    {
        // Instantiate creates a prefab (bullet)
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        // Sets bullet position to launch position (gun barrel)
        bullet.transform.position = launchPosition.position;
        return bullet.GetComponent<Rigidbody>();
    }

    public void ChangeWeapon()
    {
        if (semiAuto == true)
        {
            semiAuto = false;
        }
        else
        {
            semiAuto = true;
        }
    }
}
