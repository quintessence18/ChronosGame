using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWatch : MonoBehaviour
{

    public static PlayerWatch instance; //makes the script static

    void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public GameObject pauseScreen;
    public bool lockCursor;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        if (pauseScreen.activeInHierarchy)
        {
            if (Cursor.visible == false)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
