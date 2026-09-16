using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float currentPipeSpeed = 3f; // Current speed of the pipes
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text scoreCardText;


    [SerializeField] private Image medalImage;      
    [SerializeField] private Sprite goldMedalSprite; 
    [SerializeField] private Sprite silverMedalSprite; 
    [SerializeField] private Image newImage;


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

        if (score % 5 == 0) // Increase pipe speed every 5 points
        {
            currentPipeSpeed += 0.5f;
        }

    }

    public void hideScoreText() 
    {
        scoreText.gameObject.SetActive(false);
    }

    public void scoreCardStats() 
    {
        bool ısNewRecord = score > PlayerPrefs.GetInt("highScore");

        if (ısNewRecord)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        PlayerPrefs.Save();

        highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
        scoreCardText.text = score.ToString();

        // medal image update based on whether it's a new record or not
        if (ısNewRecord)
        {
            medalImage.sprite = goldMedalSprite;
            newImage.gameObject.SetActive(true); // Show the new image when it's a new record
        }
        else
        {
            medalImage.sprite = silverMedalSprite;
            newImage.gameObject.SetActive(false);
        }
    }

    
    public void StartGame() 
    {
        SceneManager.LoadScene("Game");
        BackgroundMusic.instance.gameObject.GetComponent<AudioSource>().UnPause();
    }

    public void MainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
        BackgroundMusic.instance.gameObject.GetComponent<AudioSource>().UnPause();
    }
}
