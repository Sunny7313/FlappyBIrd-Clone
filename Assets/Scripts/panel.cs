using UnityEngine;
using UnityEngine.SceneManagement;

public class panel : MonoBehaviour
{
    [SerializeField] private GameObject panelObject;
    [SerializeField] private GameObject pauseObject;
    private void Awake()
    {
        panelObject.SetActive(false);
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0f;
        panelObject.SetActive(true);
        pauseObject.SetActive(false);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        panelObject.SetActive(false);
        pauseObject.SetActive(true);
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }
   
}
