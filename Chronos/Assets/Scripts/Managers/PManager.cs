using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class PManager : MonoBehaviour
{
    public bool lockCursor;
    public GameObject player;//to get my player controller script
    public GameObject crosshair;
    public GameObject time;//to get my timescript
    [SerializeField] private bool isPaused;//verify the game is paused etc.
    public GameObject PauseMenu;
    public GameObject GameManager;
    public float TimeUnfrozen;//variable to control the factor of normal time etc
    PlayerController controller;

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
        player.GetComponent<PlayerController>().enabled = false;//to turn my playerController off - you initialy refreence to the parent
        crosshair.SetActive(false);//turns off my crosshairs
        time.GetComponent<TimeEffect>().enabled = false;//to make my game stop completely
        Time.timeScale = 0;//turns time off;
    }

    public void Resume()
    {
        time.GetComponent<TimeEffect>().enabled = true;//to make my time effect activate again
        crosshair.SetActive(true);//turns my crosshair back on
        PauseMenu.SetActive(false);//turns off my pause menu
        player.GetComponent<PlayerController>().enabled = true;//to turn my playerController back on 

    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");//loads main menu
    }
}
