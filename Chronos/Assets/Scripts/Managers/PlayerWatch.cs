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

}
