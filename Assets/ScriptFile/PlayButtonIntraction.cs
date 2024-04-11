using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayButtonIntraction : MonoBehaviour
{
    private TextMeshProUGUI input_name;
    private Button button;

    private void Start()
    {
        input_name=GameObject.Find("name_of_the_player").GetComponent<TextMeshProUGUI>();
        button=GameObject.Find("Play").GetComponent<Button>();
        button.interactable = false;

    }
    private void Update()
    {
        string name =input_name.text;
        Debug.Log(name + " it is the name of player in the match !!");
        if(name.Length>=1)
        {
            button.interactable = true;
        }

    }

}
