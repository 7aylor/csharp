using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
    private LevelManager levelManager;
    public Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    //if there is a collision with the lose collider
    void OnTriggerEnter2D(Collider2D trigger)
    {
        //decrease number of lives
        Ball.numberOfLives--;

        //check if we have enough lives to continue playing and update the UI
        if (Ball.numberOfLives > 0)
        {
            ball.isBallShot = false;
            Ball.tr.enabled = false;
            ball.ResetBallToStartPosition();
            UI.PrintNumberOfLives();
        }
        //otherwise, load the lose menu
        else
        {
            Ball.InitNumberOfLives();
            levelManager = FindObjectOfType<LevelManager>();
            levelManager.LoadLevel("Lose Menu");
        }
    }
}
