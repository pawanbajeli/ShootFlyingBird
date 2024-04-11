using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RankDecideUsingJsonData : MonoBehaviour
{
    private DataAccess dataAccess;
    public float initialYPosition =-421f; // Initial Y position for the first row
    public float yOffset = -57f; // Y offset for subsequent rows


    private TextMeshProUGUI current_score;
    private TextMeshProUGUI best_score;
    
    

    //getting current players current and best score
    int present_score;
    int all_time_best;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "LeaderBoard")
        {
            GameObject obj = GameObject.Find("currentPointShow");
            current_score=obj.GetComponent<TextMeshProUGUI>();

            GameObject obj1 = GameObject.Find("BestPointShow");
            best_score=obj1.GetComponent<TextMeshProUGUI>();
        }
       
    }
    private void Start()
    {
        GameObject score_template = transform.GetChild(2).gameObject;
        string current_player_name = PlayerPrefs.GetString("PlayerName");
        current_player_name=current_player_name.ToLower();
        
        
        GameObject g;
        int rank = 1;
        dataAccess = FindObjectOfType<DataAccess>();
        PlayerList playerData = dataAccess.GetPlayerData();


        if (dataAccess != null)
        {
            
           
            if (playerData != null)
            {
                float currentYPosition = initialYPosition;
                playerData.players.Sort((a, b) => b.best_score.CompareTo(a.best_score));
                foreach (PlayerData player in playerData.players)
                {
                    if (rank <= 12)
                    {
                        g = Instantiate(score_template, transform);
                        RectTransform rectTransform = g.GetComponent<RectTransform>();

                        // Set the vertical position based on currentYPosition
                        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, currentYPosition);
                        g.transform.GetChild(0).gameObject.GetComponent<Text>().text = rank.ToString();
                        rank++;
                        g.transform.GetChild(1).gameObject.GetComponent<Text>().text = player.Name;
                        
                        g.transform.GetChild(2).gameObject.GetComponent<Text>().text = player.best_score.ToString();
                        
                        if(player.Name==current_player_name)
                        {
                            present_score = GameManager.scores;
                            all_time_best = player.best_score;
                        }

                        currentYPosition += yOffset;

                    }
                }
                
            }
        }
        else
        {
            Debug.LogError("DataAccessScript not found in the scene.");
        }



        if (SceneManager.GetActiveScene().name == "LeaderBoard")
        {
            current_score.text=present_score.ToString();
            best_score.text=all_time_best.ToString();
        }


    }

   
}
