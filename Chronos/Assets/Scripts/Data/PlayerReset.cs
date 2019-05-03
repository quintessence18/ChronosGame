using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerReset : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);//takes the player back to the start of the game
    }
}


