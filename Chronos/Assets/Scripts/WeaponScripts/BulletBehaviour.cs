using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)// acts when it collides with a game object
    {
        Destroy(gameObject);
    }

}
