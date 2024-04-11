using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    //// Start is called before the first frame update
    public GameObject target;
    public AudioSource crow;


    //private GameObject target;

    public Text score_Text;
    int score = 0;


    //to change the Texture
    public Texture2D crosshairCursorTexture;


    public Text player_name_Text;



    ////data structure to store the values of scenes
    //Dictionary<int,string> scene_name = new Dictionary<int,string>();   

    //for the json files
    public JsonDataHandler jsonFile;


    //this text field is used to store the timer information of the user
    private Text countdownText;
    private int currentValue = 15;
    private float countdownTimer = 1f;
    [SerializeField]
    private GameObject overPanel;
    //to Stop the spwan of the objects
    bool IsGameOver=false;

    public static int scores;
    //GameObject to Inactive the Things
    GameObject Current_UserData;




    


    //accessing a script which is used to handle the data related to the json and the database
    // public JsonData_Handler JsonHandle;







    //start function
    void Start()
    {


        Cursor.SetCursor(crosshairCursorTexture, Vector2.zero, CursorMode.Auto);
        crow.Play();

            if (target != null)
            {
                InvokeRepeating("spwan", 1.0f, 1.5f);


            }
            else
                print("not accesss");

        if (overPanel != null)
        {
            overPanel.SetActive(false);
        }
        GameObject obj = GameObject.FindWithTag("player_point");
        if (obj != null)
            score_Text = obj.GetComponent<Text>();



        GameObject obj1 = GameObject.Find("Reaming_time");
        if (obj1 != null)
        {
            countdownText = obj1.GetComponent<Text>();

            countdownText.text = (15.0f).ToString();
        }




        GameObject obj3 = GameObject.FindWithTag("PlayerInfo");
        if (obj3 != null)
        {
            player_name_Text = obj3.GetComponent<Text>();
            string name = PlayerPrefs.GetString("PlayerName");
            player_name_Text.text = name;

        }

        Current_UserData = GameObject.FindWithTag("PlayerCurrentData");
        Current_UserData.SetActive(true);






    }


    void spwan()
    {

        if (IsGameOver != true)
        {
            float randX = Random.Range(-8.5f, 7.5f);
            float randY = Random.Range(-4.05f, 3.98f);

            Vector3 ranpos = new Vector3(randX, randY, 0);

            Instantiate(target, ranpos, Quaternion.identity);
        }


    }

    public void incrementScore()
    {
        score++;
        score_Text.text = score.ToString();
        scores=int.Parse(score_Text.text);

        print(score);
    }


    


    
    private void Update()
    {


       
        countdownTimer -= Time.deltaTime;

        if (countdownTimer <= 0f)
        {
            if (currentValue > 0)
                currentValue--;

            countdownText.text = currentValue.ToString();

            if (currentValue <= 0 && IsGameOver == false)
            {

                currentValue = 0;
                IsGameOver = true;

                jsonFile.SavePlayerData(player_name_Text.text.ToLower(), int.Parse(score_Text.text.ToString()));
                if (currentValue <= 0)
                {
                    Debug.Log("Game Over Panel is Called!");
                    Current_UserData.SetActive(false);
                    crow.Stop();
                    overPanel.SetActive(true);
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

                }

            }

            countdownTimer = 1f;
            Debug.Log("the current value is" + currentValue);
        }


    }

    



}
