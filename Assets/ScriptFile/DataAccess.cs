using UnityEngine;

public class DataAccess : MonoBehaviour
{
    public PlayerList GetPlayerData()
    {
        
        JsonDataHandler jsonDataHandler = FindObjectOfType<JsonDataHandler>();
        if (jsonDataHandler != null)
        {
            return jsonDataHandler.playerDataList;
        }
        else
        {
            Debug.LogError("JsonDataHandler not found in the scene.");
            return null;
        }
    }
}
