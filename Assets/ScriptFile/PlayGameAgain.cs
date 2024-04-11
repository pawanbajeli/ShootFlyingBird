using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameAgain : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GetScoreLeader()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
