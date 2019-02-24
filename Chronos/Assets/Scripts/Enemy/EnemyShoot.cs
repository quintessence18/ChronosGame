using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
        public GameObject bulletPrefab;//to take the bullets prefab and instantiate
        public Transform bulletSpawn;//the set spawnPoint 
        public float bulletSpeed = 30;//how fast the bullet will fly
        public float lifeTime = 3;//how long the bullet will last
        public float waitTime;//The time to wait until firing again
        private float currentTime;//Checking the time  until firing 
        private bool shot;//verifies if anything has been shot
        private Transform bulletSpawned;//Checks if the bullet has been spwaned
        public GameObject player;//Takes the position of the player

        public void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.LookAt(player.transform);//tells the object to look at the player
    
            if (currentTime == 0)//if the currentTime counter is 0
            {
                Fire();//run the fire method
            }
    
    
            if (shot && currentTime < waitTime)//if the bullet hasn't been shot and the current time is 0
            {
                currentTime += 1 * Time.deltaTime;//increments the counting by 1 in the worlds set timescale
            }
    
    
            if (currentTime >= waitTime)
            {
                currentTime = 0;// makes sure that the current time will set to 0
            }
    
        }
    
        //fire function to fire projectiles
        private void Fire()
        {
            shot = true;
    
            /*bulletSpawned = Instantiate(bulletPrefab.transform, bulletSpawn.transform.position, Quaternion.identity);
            bulletSpawned.transform.rotation = this.transform.rotation;*/
            GameObject bullet = Instantiate(bulletPrefab);//puts the bullet in the scene
            bullet.transform.position = bulletSpawn.position;//spawns bullet in the set spawnpoint
            Vector3 rotation = bullet.transform.rotation.eulerAngles;//converts rotation angles to vector 3
            bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z); //keeps same rotation of bullet, makes it face forward
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);//ensures bullet is instantly launched forward at a fast speed
        }
}
