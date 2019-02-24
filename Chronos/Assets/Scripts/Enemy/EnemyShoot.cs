using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
        public GameObject bulletPrefab;
        public Transform bulletSpawn;
        public float bulletSpeed = 30;//how fast the bullet will fly
        public float lifeTime = 3;//how long the bullet will last
        public float waitTime;
        private float currentTime;
        private bool shot;
        private Transform bulletSpawned;
    
        public GameObject player;
    
    
    
        public void Start()
        {
            player = GameObject.FindWithTag("Player");
        }
    
    
        // Update is called once per frame
        void Update()
        {
            this.transform.LookAt(player.transform);
    
            if (currentTime == 0)
            {
                Fire();
            }
    
    
            if (shot && currentTime < waitTime)
            {
                currentTime += 1 * Time.deltaTime;
            }
    
    
            if (currentTime >= waitTime)
            {
                currentTime = 0;
            }
    
        }
    
        //fire function to fire projectiles
        private void Fire()
        {
            shot = true;
    
            /*bulletSpawned = Instantiate(bulletPrefab.transform, bulletSpawn.transform.position, Quaternion.identity);
            bulletSpawned.transform.rotation = this.transform.rotation;*/
            GameObject bullet = Instantiate(bulletPrefab);//puts the bullet in the scene
            bullet.name = "bullet";
            bullet.transform.position = bulletSpawn.position;//spawns bullet in the set spawnpoint
            Vector3 rotation = bullet.transform.rotation.eulerAngles;//converts rotation angles to vector 3
            bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z); //keeps same rotation of bullet, makes it face forward
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);//ensures bullet is instantly launched forward at a fast speed
        }
}
