using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using UnityEngine.SceneManagement;

public class PManager : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private bool isPaused; 
    public GameObject PauseMenu;
    public GameObject GameManager;
    public float TimeUnfrozen;//variable to control the factor of normal time etc

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            Resume();
        }

    }

    public void ActivateMenu()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;

    }

    public void Resume()
    {
        Time.timeScale = TimeUnfrozen;
        PauseMenu.SetActive(false);

    }

    public void ExitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);//loads next scene
    }
}
