using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;

    public float fireRate;

    public Camera playerCamera;

    private float nextFire;


    void Update()
    {
        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
        }
        
        if (Input.GetButton("Fire1") && nextFire <= 0)
        {
            nextFire = 1 / fireRate;
            
            Fire();
        }
    }

    void Fire()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray.origin,ray.direction, out hit, 100f))
        {
            if (hit.transform.gameObject.GetComponent<PlayerHealth>())
            {
                hit.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, damage);
            }
        }
    }
}
