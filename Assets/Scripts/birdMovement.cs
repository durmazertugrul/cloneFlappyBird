using System;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class birdMovement : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 3f;
    private Rigidbody2D rb2d;
    private void Start()
    {
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
        if (other.gameObject.tag == "Pipe") 
        {
            gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScoreArea") 
        {
            FindAnyObjectByType<GameManager>().increaseScore();
        }
    }

}
