using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    void Start()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
    }
    public void Menu()
    {
        PlayerPrefs.SetInt("Distance", 0);
        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
