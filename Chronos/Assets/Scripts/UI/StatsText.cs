using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsText : MonoBehaviour
{
    public GameObject player;
    public Text playerName;
    public Text currentLevel;
    public Text currentScore;

    private void Update()
    {
        playerName.text = player.GetComponent<PlayerData>().Name;
        currentLevel.text = player.GetComponent<PlayerData>().Level.ToString();
        currentScore.text = player.GetComponent<PlayerData>().Score.ToString();
    }
}
