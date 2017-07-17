using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public Paddle paddle;
    private Ball ball;

    //used for the StickBallToPaddle powerup
    public static int numOfSticksToPaddle = 0;
    private int maxNumSticksToPaddle = 4;

    //auto testing flag
    public bool autoTesting = false;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    void Update () {

        if(autoTesting == false)
        {
            //Creates a vector that holds the paddle's position in the game
            Vector3 paddlePos = new Vector3(8.5f, 1f, 0f);

            //Gets the mouse x position and converts it to world units
            float mousePosInBlocks = Input.mousePosition.x / 50;

            //Clamp the paddle to screen size
            paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1f, 15f);

            //sets the transform of the paddle to our new transform
            this.transform.position = paddlePos;
        }
        else
        {
            trackTheBall();
        }
        
    }

    //tracks the balls x position to ensure a win
    void trackTheBall()
    {
        this.transform.position = new Vector3(ball.transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the StickToPaddle powerup is active
        if (Brick.StickBallToPaddle == true && numOfSticksToPaddle < maxNumSticksToPaddle )
        {
            numOfSticksToPaddle++;
            ball.isBallShot = false;
            ball.ResetBallToStartPosition();
        }
        //if we have run out of sticks to paddle, reset StrickBallToPaddle and numOfSticks
        else if (numOfSticksToPaddle >= maxNumSticksToPaddle)
        {
            Brick.StickBallToPaddle = false;
            numOfSticksToPaddle = 0;
        }

        //if the ball is bigger from a powerup and hasn't hit the paddle max times
        if(Ball.isBigger && Ball.numBouncesWithBiggerBall < Ball.maxNumBouncesWithBiggerBall)
        {
            //increase the number of hits
            Ball.numBouncesWithBiggerBall++;
        }
        //if the bigger ball has hit the paddle max times, reset
        else if(Ball.numBouncesWithBiggerBall >= Ball.maxNumBouncesWithBiggerBall)
        {
            Ball.GrowBall(ball, -0.2f);
            Ball.numBouncesWithBiggerBall = 0;
            Ball.isBigger = false;
        }
    }
}