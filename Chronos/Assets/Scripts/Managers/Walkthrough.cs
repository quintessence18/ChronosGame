﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Walkthrough : MonoBehaviour
{
    public GameObject transitionScreen1;//holds loading screen 1
    public GameObject transitionScreen2;//holds loading screen 2
    public GameObject crosshair;//holds my crosshair gameobject 

    public void Start()
    {
        transitionScreen1.SetActive(false);//screen1 off
        transitionScreen2.SetActive(false);//screen2 off
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            int randomIndex = Random.Range(0, 2);//randomly chooses a number
            Debug.Log(randomIndex);//will show the number
            if (randomIndex == 1)//looks at a number and chooses the screen assigned
            {
                transitionScreen1.SetActive(true);//turns on the transition screen
                crosshair.SetActive(false);//turns off the crosshair
                StartCoroutine(waitTime());//starts the countdown time till the next level
            }
            else
            {
                transitionScreen2.SetActive(true);
                crosshair.SetActive(false);
                StartCoroutine(waitTime());
            }
        }
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(4);//timer of 4 seconds
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//loads the next level
    }
}
