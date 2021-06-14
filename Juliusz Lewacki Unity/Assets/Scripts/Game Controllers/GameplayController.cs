using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private Text scoreText, gameOverScoreText;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    [SerializeField]
    private GameObject readyButton;

    // Start is called before the first frame update
    void Awake ()
    {
        MakeInstance ();
    }

    void Start() {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void MakeInstance()
    {
        if (instance == null) {
            instance = this;
        }
    }

    public void GameOverShowPanel(int finalScore) {
        gameOverPanel.SetActive (true);
        gameOverScoreText.text = finalScore.ToString ();
        StartCoroutine (GameOverLoadMainMenu ());
    }

    public void Share() {
        Time.timeScale = 1f;
        Application.LoadLevel ("HighscoreScene");
        }

    IEnumerator GameOverLoadMainMenu() {
        yield return new WaitForSeconds (10f);
        Application.LoadLevel ("MainMenu");
    }

    public void PlayerDiedRestartTheGame() {
        StartCoroutine (PlayerDiedRestart ());
    }

    IEnumerator PlayerDiedRestart() {
        yield return new WaitForSeconds (1f);
        Application.LoadLevel ("Gameplay");
    }

    public void SetScore(int score) {
        scoreText.text = "" + score;
    }

     public void PauseTheGame() {
        Time.timeScale = 0f;
        pausePanel.SetActive (true);
        }

    public void ResumeGame() {
        Time.timeScale = 1f;
        pausePanel.SetActive (false);
        }

    public void QuitGame() {
        Time.timeScale = 1f;
        Application.LoadLevel ("MainMenu");
        }

    public void StartTheGame() {
        Time.timeScale = 1f;
        readyButton.SetActive (false);
        }
}
