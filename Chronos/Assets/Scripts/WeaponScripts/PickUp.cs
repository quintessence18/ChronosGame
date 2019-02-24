using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other)//uses collider to detect if we collided with weapon
    {
        if (other.tag == "Player")//checks that the player tag object collides with weapon
        {
            other.GetComponentInChildren<PlayerWeapon>().Reload();//calls my reload function to be made in playerWeapon 
            Destroy(gameObject);//destroys/deletes the pickup object in my scene
        }
    }
}
