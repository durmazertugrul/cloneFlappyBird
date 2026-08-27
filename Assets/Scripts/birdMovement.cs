using System;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class birdMovement : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 3f;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameManager gameManager;


    private Rigidbody2D rb2d;
    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        deathScreen.SetActive(false);
        Time.timeScale = 1f;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //Jump when press space or use left click
        {
            rb2d.linearVelocity = Vector2.up * jumpSpeed;
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameManager.hideScoreText();
        if (other.gameObject.tag == "Pipe") 
        {
            Time.timeScale = 0f;
            deathScreen.SetActive(true);
            gameManager.scoreCardStats();

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScoreArea") 
        {
            gameManager.increaseScore();
        }
    }

}
