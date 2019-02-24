using UnityEngine;
using UnityEngine.SceneManagement;//to change scene

public class PlayerDelete : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)//triggers if there is a collision
    {
        if(other.tag == "EnemyBullet")//if the enemy bullet collides with my player
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//resets the scene

        }
    }
}
