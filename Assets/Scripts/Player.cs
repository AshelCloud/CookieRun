using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D myRb;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float maxJumpCount;

    private float jumpCount;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        jumpCount = maxJumpCount;
    }

    private void Update()
    {
        if ( ( Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) ) && jumpCount > 0)
        {
            myRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Jelly"))
        {
            Destroy(collision.gameObject);

            GameManager.Instance.Score += 10;
        }
        else if(collision.CompareTag("GameOverArea"))
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = maxJumpCount;
        }
    }
}
