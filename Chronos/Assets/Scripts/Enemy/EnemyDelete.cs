﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDelete : MonoBehaviour
{
    public int score;//created a new variable score to pass the value to player data


    private void OnTriggerEnter(Collider other)// acts when it collides with a game object
    {
        if (other.tag == "Bullet")//checks for the object with a tag called Bullet(my bullet object in game)
        {
            PlayerManager.currentData.Score += 10;//sends and stores score addition in my player manager
            Destroy(this.gameObject);//removes object from game when both colliders meet/touch
            Debug.Log("Destroyed");
        }
    }
}
