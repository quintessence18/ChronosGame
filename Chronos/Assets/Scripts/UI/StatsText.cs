using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsText : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    public Text playerName;
    public Text currentLevel;
    public Text currentScore;

    private void Update()
    {
        playerName.text = playerData.Name;
        currentLevel.text = playerData.Level.ToString();
        currentScore.text = playerData.Score.ToString();
    }
}
