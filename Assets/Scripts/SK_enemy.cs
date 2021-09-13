using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SK_enemy : MonoBehaviour
{
    public GameObject player;
    public float dist;
    public float radius = 9f;

    NavMeshAgent nav;
    
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist > radius)
        {
            nav.enabled = false;

            gameObject.GetComponent<Animator>().SetTrigger("Idle");
        }

        if (dist < radius)
        {
            nav.enabled = true;
            nav.SetDestination(player.transform.position);

            gameObject.GetComponent<Animator>().SetTrigger("Zombie Run");
        }

        if (dist < 2)
        {
            nav.enabled = false;
            
            gameObject.GetComponent<Animator>().SetTrigger("Attack");
        }

    }
}
