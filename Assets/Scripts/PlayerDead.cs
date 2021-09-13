using UnityEngine;
using System.Collections;

public class PlayerDead : MonoBehaviour
{

    public GameObject Player;
    public GameObject Ragdoll;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeadZone")
        {
            Player.SetActive(false);
            Ragdoll.SetActive(true);
            Instantiate(Ragdoll, transform.position, transform.rotation);
        }
    }


}
