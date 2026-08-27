using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text scoreCardText;
    private int score;

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void increaseScore() //increase score method
    {
        score++;
        scoreText.text = score.ToString();

    }

    public void hideScoreText() 
    {
        scoreText.gameObject.SetActive(false);
    }

    public void scoreCardStats() //
    {
        if (score > PlayerPrefs.GetInt("highScore")) //highscore system
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        PlayerPrefs.Save();
        highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();

        scoreCardText.text = score.ToString();
    }



    public void StartGame() 
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }
}
