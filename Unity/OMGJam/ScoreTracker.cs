using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour {

    public static ScoreTracker Instance;

    static int score;

    static int highScore;

    private void Awake()
    {

        Screen.SetResolution(731, 411, false);

        score = 0;
        highScore = score;

        //if the Rounds instance hasn't been created
        if (Instance == null)
        {
            //set it to this instance
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public static void SetScore(int newScore)
    {
        score = newScore;

        if(score > highScore)
        {
            highScore = score;
        }
    }

    public static int GetScore()
    {
        return score;
    }

}
