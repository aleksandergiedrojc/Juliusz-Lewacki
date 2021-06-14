using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;
public class CloudOnceServices : MonoBehaviour
{
    public static CloudOnceServices instance;
    private void Awake()
    {
        TestSingleton();
    }

    // Update is called once per frame
    private void TestSingleton() 
    {
        if (instance != null ) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SubmitScoreToLeaderboard(int score) {
        Leaderboards.NajlepszyWynik.SubmitScore(score);
    }
}
