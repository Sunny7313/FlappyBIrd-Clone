using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float jump; 
    [SerializeField] private float delay;
    [SerializeField] private Sprite[] digitSprites;
    [SerializeField] private Image[] digits;
    [SerializeField] private GameObject[] disableObjects;
    [SerializeField] private GameObject enableObject;
    [SerializeField] private AudioSource flapSound;
    private bool isTracking = false;
    private bool start = false;
    private float score;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(delayTime());
        Time.timeScale = 0f;
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        enableObject.SetActive(false);
    }
    private void StartGame()
    {
        if (!start)
        {
            start = true;
            Time.timeScale = 1f;
            gameObject.SetActive(true);
            enableObject.SetActive(true);
            foreach (GameObject obj in disableObjects)
            {
                obj.SetActive(false);
            }
            UpdateScoreImages(0);
        }   
    }
    private void UpdateScoreImages(int value)
    {
        string scoreStr = value.ToString().PadLeft(digits.Length, '0');
        for (int i = 0; i < digits.Length; i++)
        {
            int digit = scoreStr[i] - '0';
            digits[i].sprite = digitSprites[digit];
        }
    }
    private IEnumerator delayTime()
    {
        yield return new WaitForSeconds(delay);
        isTracking = true;
    }
    void Update()
    {
        if (!start && (Input.GetKeyDown(KeyCode.Space) ||
            (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
        {
            StartGame();
            return; 
        }

        if (start && (Input.GetKeyDown(KeyCode.Space) ||
            (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
        {
            Jump();
        }

        if (isTracking)
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", Mathf.FloorToInt(score));
            }
        }
    }
    void Jump()
    {
        flapSound.Play();
        rb.velocity = new Vector2(rb.velocity.x, jump);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isTracking = false;
            Destroy(gameObject);
            PlayerPrefs.SetInt("Score", Mathf.FloorToInt(score));
            SceneManager.LoadScene("GameOver");
        }
        if (collision.CompareTag("Score"))
        {
            score++;
            UpdateScoreImages((int)score);
        }
    }
}
