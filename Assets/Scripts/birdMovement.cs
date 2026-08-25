using System;
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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            rb2d.linearVelocity = Vector2.up * jumpSpeed;
        }
    }
}
