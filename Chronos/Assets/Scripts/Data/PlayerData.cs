using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

public class PlayerData : MonoBehaviour
{
    [SerializeField] PManager manager;
    public string Name;//stores the username
    public int Level;//stores the level the user is on
    public int Score;//stores thex user's score

    void Save()//used to save the user's progress
    {
        Name = Login.Instance.Username;
        JSONObject playerJson = new JSONObject();//new JsonObject used to save player data
        playerJson.Add("Name", Name);//used as the "first" element to store user's name
        playerJson.Add("Level", Level);//used as the "second" element to store user's Level
        playerJson.Add("Score", Score);//used as the "third" element to store user's Score
        //Position
        JSONArray position = new JSONArray();//defines the variable to hold the user's position
        position.Add(transform.position.x);//stores the x coordinates
        position.Add(transform.position.y);//stores the y coordinates
        position.Add(transform.position.z);//stores the z coordinates
        playerJson.Add("Position", position);//stores the coordinates in the position variable

        Debug.Log("Name is:" + Name);
        //Saves data to Computer
        string path = Application.persistentDataPath + Name + ".json";//creates a new path with the user's data
        File.WriteAllText(path, playerJson.ToString());//writes all the text to the set path as a string
    }

    void Load()//used to load back user's data
    {
        string path = Application.persistentDataPath + Name + ".json";//checks for the nameed filepath and assigns to path
        string jsonString = File.ReadAllText(path);//reads all data in the path
        JSONObject playerJson = (JSONObject)JSON.Parse(jsonString);//creates a json object to access each value, using parse
        Name = playerJson["Name"];//gets the value from the element labled Name
        Level = playerJson["Level"];//gets the value  from the element labled Level
        Score = playerJson["Score"];//gets the value  from the element labled Score

        //position
        transform.position = new Vector3(
        playerJson["Position"].AsArray[0],
        playerJson["Position"].AsArray[1],
        playerJson["Position"].AsArray[2]);//pulls the position vectors of x,y, and z
    }

    private void Start()
    {
        Save();
        Load();
    }

}
