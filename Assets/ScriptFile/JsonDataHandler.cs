using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;

[System.Serializable]
public class PlayerData : IComparable<PlayerData>
{
    public string Name;
    public int best_score;
    public int curr_score;


    public int CompareTo(PlayerData other)
    {
        // Compare by current score in descending order (high to low).
        return other.best_score.CompareTo(best_score);
    }

}
[System.Serializable]
public class PlayerList
{
    public List<PlayerData> players = new List<PlayerData>();
}

public class JsonDataHandler : MonoBehaviour
{
    private static JsonDataHandler instance;
    public PlayerList playerDataList;
    static string jsonFilePath;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        


    }



    //read the json file and store its data in list 
    //iteraate over the list
    //if the player present in the list then only swap its score means the new score with current and the previous_current score with previous score
    //if the player is new then add the player in the data base and assign 0 to previous score and current _score to present socre
   

    //prefab to update the values


    private void Start()
    {
        playerDataList = new PlayerList();
        jsonFilePath = "Assets/Resources/Player_Data.Json";

       LoadPlayerData();
       
    }


    public void SavePlayerData(string playerName, int playerScore)
    {


        // Search for the player with the given name
        //PlayerData existingPlayer = playerDataList.players.Find(player => player.Name == playerName);
        if (playerDataList == null)
        {
            Debug.Log("no file found");
        }
        else
        {
            LoadPlayerData();
            PlayerData existingPlayer = playerDataList.players.Find(player => player.Name == playerName);
            if (existingPlayer != null)
            {
                Debug.Log("Name of exiting player: " + existingPlayer.Name);
                existingPlayer.best_score = Mathf.Max(existingPlayer.best_score, playerScore);
                existingPlayer.curr_score = playerScore;
            }
            else
            {
                PlayerData playerData = new PlayerData
                {
                    Name = playerName,
                    curr_score = playerScore,
                    best_score = playerScore
                };
                playerDataList.players.Add(playerData);
            }


            // Serialize the list to JSON
            string jsonData = JsonUtility.ToJson(playerDataList);

            // Save JSON data to a file
            File.WriteAllText(jsonFilePath, jsonData);
            
        }
    }


    private void LoadPlayerData()
    {
        

        if (File.Exists(jsonFilePath))
        {
            // Read existing JSON data from the file
            string jsonData = File.ReadAllText(jsonFilePath);

            // Deserialize JSON data into playerDataList
            playerDataList = JsonUtility.FromJson<PlayerList>(jsonData);

            if (playerDataList == null)
            {
                // The JSON file is empty or contains invalid data
                playerDataList = new PlayerList();
            }
            else
            {
                // Ensure the players list is not null
                if (playerDataList.players == null)
                {
                    playerDataList.players = new List<PlayerData>();
                }

                // Sort the players list
                playerDataList.players.Sort((a, b) => b.best_score.CompareTo(a.best_score));
            }
        }
        else
        {
            Debug.Log("No File Found at " + jsonFilePath);
            // Create a new PlayerList when the file doesn't exist
            playerDataList = new PlayerList();
        }


    }







}
