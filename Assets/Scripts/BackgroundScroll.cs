using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField]
    private Vector2 scrollSpeed;

    private Material material;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (GameManager.Instance.IsStart == false) { return; }

        if (GameManager.Instance.IsGameOver == false)
        {
            material.mainTextureOffset += scrollSpeed * Time.deltaTime;
        }
    }

}
