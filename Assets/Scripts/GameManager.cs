using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int score;

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void increaseScore() 
    {
        score++;
        scoreText.text = score.ToString();
    }

}
