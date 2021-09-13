using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700f;

    float countdown;
    bool hasExploded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        
       countdown -= Time.deltaTime;

        if (countdown <= 0f && hasExploded == false)
        {
            Explode();
            hasExploded = true;
            
        }
        //Instantiate(explosionEffect, transform.position, transform.rotation); // взрыв и пожар в уровне!
    }

    void Explode()
    {
        // эффект взрыва

        Instantiate(explosionEffect, transform.position, transform.rotation);

        // найти ближайшие объекты

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            //применить силу к ним

            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

            // нанести урон
        }



        // бомба исчезает

        Destroy(gameObject);
        

    }
}
