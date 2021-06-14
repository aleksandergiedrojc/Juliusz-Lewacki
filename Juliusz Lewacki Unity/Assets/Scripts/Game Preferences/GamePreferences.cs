using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences
{


    public static string MediumDifficulty = "MediumDifficulty";
    
    public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";

    public static string IsMusicOn = "IsMusicOn";

    public static int GetMusicState() {
        return PlayerPrefs.GetInt(GamePreferences.IsMusicOn);
    }

    public static void SetMusicState(int state) {
        PlayerPrefs.SetInt  (GamePreferences.IsMusicOn, state);
    }
        
     public static int GetMediumDifficultyState() {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficulty);
    }

    public static void SetMediumDifficultyState(int state) {
        PlayerPrefs.SetInt (GamePreferences.MediumDifficulty, state);
    }

     public static int GetMediumDifficultyHighscore() {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyHighScore);
    }

    public static void SetMediumDifficultyHighscore (int score) {
        PlayerPrefs.SetInt (GamePreferences.MediumDifficultyHighScore, score);
    }
    
}
