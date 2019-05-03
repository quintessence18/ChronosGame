using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    private static scoreManager instance;// ensures no other score managing instance is available but this
    public static scoreManager Instance { get { return instance; } }
    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

    [SerializeField] PlayerData playerdata;//accesses the player data script
    public int Score;

    public void Update()
    {
        playerdata.Score = Score;
    }
}
