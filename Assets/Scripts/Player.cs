using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D myRb;

    [SerializeField]
    private Animator animator;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.D) && GameManager.Instance.IsStart)
        {
            animator.SetTrigger("Slept");

            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Jelly"))
        {
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("Castle"))
        {
            GameManager.Instance.Clear();
        }
    }
}
