using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    [SerializeField]
    private Vector2 scrollSpeed;

    private void Update()
    {
        if (GameManager.Instance.IsGameOver == false)
        {
            transform.Translate(scrollSpeed * Time.deltaTime);
        }
    }
}
