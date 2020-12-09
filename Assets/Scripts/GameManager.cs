using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private GameObject PausePage;

    [SerializeField]
    private GameObject warningPage;

    [SerializeField]
    private GameObject warningText;

    [SerializeField]
    private GameObject clearPage;

    public bool IsGameOver { get; set; }

    public bool IsStart { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;

        IsGameOver = false;
        IsStart = false;

        StartCoroutine(ShowWarningPage());
    }

    public void PauseGame()
    {
        IsStart = false;

        Time.timeScale = 0f;

        PausePage.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;

        PausePage.SetActive(false);

        StartCoroutine(ShowWarningPage());
    }

    private IEnumerator ShowWarningPage()
    {
        warningPage.SetActive(true);

        while (Input.GetKey(KeyCode.D) == false)
        {
            warningText.SetActive(true);

            yield return new WaitForSeconds(1f);

            warningText.SetActive(false);

            yield return new WaitForSeconds(1f);
        }

        warningPage.SetActive(false);

        IsStart = true;

        yield return null;
    }

    public void GameOver()
    {
        IsGameOver = true;

        StartCoroutine(GameOverCoroutine());
    }

    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("Game");
    }

    public void Clear()
    {
        Time.timeScale = 0f;

        clearPage.SetActive(true);
    }
}
