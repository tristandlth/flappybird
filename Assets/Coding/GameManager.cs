using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int Score;
    public Button restartButton;

    void Start()
    {
        Time.timeScale = 0f;
        restartButton.onClick.AddListener(() => restartGame());
        restartButton.gameObject.SetActive(false);
    }

    void restartGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void killPlayer()
    {
        OnPlayerDie();
    }

    void OnPlayerDie()
{
    Time.timeScale = 0f;

    RectTransform scoreTextRect = scoreText.GetComponent<RectTransform>();
    scoreTextRect.anchoredPosition = new Vector2(-410, -180);

    scoreText.text = "You died. Press R to restart. Your best score is: " + Score;

    restartButton.gameObject.SetActive(true);
}


    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            Time.timeScale = 1f;
        }

        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void addScore(){
        Score++;
        scoreText.text = "Score : " + Score;
    }
}
