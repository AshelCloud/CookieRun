using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private Text gameoverText;

    [SerializeField]
    private Text scoreText;

    public bool IsGameOver { get; set; }

    public int Score { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameoverText.enabled = false;
        IsGameOver = false;
        Score = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(IsGameOver == false)
            {
                return;
            }

            SceneManager.LoadScene("Game");
        }

        scoreText.text = "점수: " + Score.ToString();
    }

    public void GameOver()
    {
        gameoverText.enabled = true;

        IsGameOver = true;
    }
}
