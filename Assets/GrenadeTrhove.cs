using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GrenadeTrhove : MonoBehaviour
{
    public float trowForce = 4f;
    public GameObject grenadePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TrowGrenade();
        }
    }

    void TrowGrenade()
    {
       GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);

        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * trowForce); //ForceMode.VelocityChange
    }
}
