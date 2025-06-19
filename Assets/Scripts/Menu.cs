using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Text HighScoreText;
    void Start()
    {
       HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
