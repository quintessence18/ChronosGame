using UnityEngine;

public class GunMov : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //gets the player's vector position and assigns it to playerPos
        Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;
        //the gun turns to look at the player(moves facing the position)
        transform.LookAt(playerPos);
    }
}
