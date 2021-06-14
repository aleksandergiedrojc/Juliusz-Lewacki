using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

        [HideInInspector]
    public int score;
    // Start is called before the first frame update
    void Awake()
    {
        MakeSingleton ();
    }

    void Start() {
        InitializeVariables();
    }

    // Update is called once per frame
    void OnLevelWasLoaded()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay") {

            if (gameRestartedAfterPlayerDied) {

                GameplayController.instance.SetScore(score);

                PlayerScore.scoreCount = score;

                
             } else if(gameStartedFromMainMenu) {
                 PlayerScore.scoreCount = 0;

                 GameplayController.instance.SetScore(0);
            }
        }
    }

    void InitializeVariables() {

        if (!PlayerPrefs.HasKey ("Game Initialized")) {

            GamePreferences.SetMediumDifficultyState(1);
            GamePreferences.SetMediumDifficultyHighscore(0);

            GamePreferences.SetMusicState(0);

            PlayerPrefs.SetInt("Game Initialized", 123);
        }
    }

    void MakeSingleton() {
        if (instance != null) {
            Destroy (gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad (gameObject);    
        }
    }

    public void CheckGameStatus(int score){
        
        if(GamePreferences.GetMediumDifficultyState() == 1) {
            int highScore = GamePreferences.GetMediumDifficultyHighscore();

            if(highScore < score)
                GamePreferences.SetMediumDifficultyHighscore(score);
        }

        this.score = score;

        gameStartedFromMainMenu = false;
        gameRestartedAfterPlayerDied = false;

        GameplayController.instance.GameOverShowPanel(score);
    
}

}
