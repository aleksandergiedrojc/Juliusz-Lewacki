using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        SetScoreBasedOnDifficulty ();
    }

    void SetScore(int score) {
        scoreText.text = score.ToString();

        CloudOnceServices.instance.SubmitScoreToLeaderboard(score);
    }

    void SetScoreBasedOnDifficulty() {

        if (GamePreferences.GetMediumDifficultyState () == 1) {
            SetScore(GamePreferences.GetMediumDifficultyHighscore());
        }
    }

    public void GoBackToMainMenu() {
        Application.LoadLevel("MainMenu");
    }



}
