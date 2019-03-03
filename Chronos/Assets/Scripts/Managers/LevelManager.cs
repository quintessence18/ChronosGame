using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] PlayerData playerdata;
    public int Level;
    void Start()
    {
        string currentName = SceneManager.GetActiveScene().name;

        if (currentName == "Tutorial")//checks the name of the scene
        {

            playerdata.Level = 1;

        }
        if (currentName == "Level1")
        {
            playerdata.Level = 2;

        }
        if (currentName == "Level 2")
        {
            playerdata.Level = 3;

        }
    }

}
