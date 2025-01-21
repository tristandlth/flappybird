using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int Score;
    public Button restartButton;

    // Audio
    public AudioSource soundMusic;
    public AudioSource soundScore;

    public GameObject Tuyau;
    public GameObject Tuyau_Top;

    void Start()
    {
        Time.timeScale = 0f;
        restartButton.onClick.AddListener(() => restartGame());
        restartButton.gameObject.SetActive(false);
    }

    void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void killPlayer()
    {
        OnPlayerDie();
        soundMusic.Stop();
    }

    void OnPlayerDie()
    {
        Time.timeScale = 0f;

        RectTransform scoreTextRect = scoreText.GetComponent<RectTransform>();
        scoreTextRect.anchoredPosition = new Vector2(-400, -224);

        scoreText.text = "Score : " + Score;
        scoreText.fontSize = 30;

        restartButton.gameObject.SetActive(true);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void addScore()
    {
        // Change la position X et Y du score
        RectTransform scoreTextRect = scoreText.GetComponent<RectTransform>();
        scoreTextRect.anchoredPosition = new Vector2(-330, -224);

        // Joue le son et met à jour le score
        soundScore.Play();
        Score++;
        scoreText.text = Score.ToString();
    }
}
