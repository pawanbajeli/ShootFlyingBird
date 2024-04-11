using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneHandler : MonoBehaviour
{
    
    public TextMeshProUGUI player_name_text;
    public GameObject panel;
 


    //data structure to store the values of scenes
    Dictionary<int, string> scene_name = new Dictionary<int, string>();
    private void Awake()
    {
        scene_name[0] = "MainMenu";
        scene_name[1] = "GameScene";
        scene_name[2] = "leaderboard";
       

    }


    private void Start()
    {
        panel.SetActive(false);
       
    }

    

    public void nextScene()
    {

        Debug.Log("this game objects tag is " + gameObject.tag);
        int tag = int.Parse(gameObject.tag);

        if (tag != 3)
        {
            if (tag == 1)
            {

                panel.SetActive(true);
               
               

            }
            else
                SceneManager.LoadScene(scene_name[tag]);
        }
        else
        {
            Application.Quit();
        }

    }

    public void playGame()
    {
        
        
        
        PlayerPrefs.SetString("PlayerName", player_name_text.text);
        string name = PlayerPrefs.GetString("PlayerName");
        if (name != null)
        {
            int tag = int.Parse(gameObject.tag);
            SceneManager.LoadScene(scene_name[tag]);
        }
        else
        {
            Debug.Log("Enter the Name!");
        }
    }



}
