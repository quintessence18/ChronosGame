using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject bulletPrefab; // a prefab to instanciate
    public Transform bulletSpawn; // will use the spawnpoint
    public float bulletSpeed = 30;//how fast the bullet will fly
    public float lifeTime = 3;//how long the bullet will last
    private int currentAmmo;//used to check how much ammo i have left
    public int maxAmmo = 6;//sets maximum ammo to what value i would like


    private void Start()
    {
        currentAmmo = maxAmmo;//sets ammo to 6 at the start of the game
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))//gets the right mouse button
        {
            if (currentAmmo > 0)//when my ammo level is bigger than 0
            {
                Fire();//runs the fire function
            }
            else
            {
                print("no ammo left");//otherwise I can't shoot
            }
        }
    }

    //my reload function
    public void Reload()
    {
        currentAmmo = maxAmmo;//resets the current ammo back to my set value
    }

    //fire function to fire projectiles
    private void Fire()
    {
        currentAmmo--;//decreases the currentAmmo's value by 1 each time it calls the fire script
        GameObject bullet = Instantiate(bulletPrefab);//puts the bullet in the scene
        bullet.transform.position = bulletSpawn.position;//spawns bullet in the set spawnpoint
        Vector3 rotation = bullet.transform.rotation.eulerAngles;//converts rotation angles to vector 3
        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z); //keeps same rotation of bullet, makes it face forward
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);//ensures bullet is instantly launched forward at a fast speed
        StartCoroutine(DestroyBulletATime(bullet, lifeTime));//counts down the set lifetime, then deestroys the bullet when the timer hits 0
    }

    private IEnumerator DestroyBulletATime(GameObject bullet, float delay)//waits for frame to end then deletes the fired bullet from scene
    {
        yield return new WaitForSeconds(delay);//waits during the unscaled time - since my scene will have time slowed down at certain points
        Destroy(bullet);//destroys bullet when lifetime has passed
    }
}
