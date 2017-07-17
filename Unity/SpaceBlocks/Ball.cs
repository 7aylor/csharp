using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public bool isBallShot = false;
    public static int numberOfLives = 3;
    public AudioClip[] audioClips;
    public static TrailRenderer tr;
    public static int numBouncesWithBiggerBall = 0;
    public static int maxNumBouncesWithBiggerBall = 5;
    public static bool isBigger = false;

    private AudioSource ballAudio;
    private AudioClip laser;
    private AudioClip bump;
    private Paddle paddle;
    private Rigidbody2D ballRigidBody;

    void Start()
    {
        tr = GetComponent<TrailRenderer>();
        tr.enabled = false;
        paddle = FindObjectOfType<Paddle>();
        ballRigidBody = GetComponent<Rigidbody2D>();
        laser = audioClips[0];
        bump = audioClips[1];
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        Vector2 tweakTrajectory;
        if (ballRigidBody.velocity.y < 0.5f && ballRigidBody.velocity.y > -0.5f)
        {
            tweakTrajectory = new Vector2(0f, 3f);
        }
        else
        {
            tweakTrajectory = new Vector2(Random.Range(-0.5f, 0.5f), 0f);
        }
        ballRigidBody.velocity += tweakTrajectory;
        AudioSource.PlayClipAtPoint(bump, transform.position);
    }

    void Update()
    {
        IsShot();
    }

    public void IsShot()
    {
        //if the ball has not been shot yet
        if (isBallShot == false)
        {
            ResetBallToStartPosition();
            //rotate the ball while its floating above the paddle
            gameObject.transform.Rotate((new Vector3(0, 0, 45)) * Time.deltaTime);
        }
    }

    public void ResetBallToStartPosition()
    {
        //attach the ball to the top center of the paddle
        transform.position = new Vector3(paddle.transform.position.x, 1.5f, 0f);

        //if the user presses the left mouse button
        if (Input.GetMouseButtonDown(0))
        {

            //give the ball some velocity and set isShot to true
            ballRigidBody.velocity = new Vector2(Random.Range(-1f, 1f), 12f);
            isBallShot = true;
            tr.enabled = true;
            if(laser != null)
            {
                AudioSource.PlayClipAtPoint(laser, transform.position);
            }
            //else
            //{
            //    print("laser audio not found");
            //}
        }
    }

    public static void InitNumberOfLives()
    {
        numberOfLives = 3;
    }

    public static void PowerUpSlowBall(Ball ball)
    {
        ball.ballRigidBody.velocity = new Vector2(ball.ballRigidBody.velocity.x + (ball.ballRigidBody.velocity.x * -0.25f), 
                                                  ball.ballRigidBody.velocity.y + (ball.ballRigidBody.velocity.y * -0.25f));
    }

    public static void PowerUpGrowBall(Ball ball)
    {
        isBigger = true;
        GrowBall(ball);
    }

    public static void GrowBall(Ball ball, float growth = 0.2f)
    {
        ball.transform.localScale = new Vector3(ball.transform.localScale.x + growth, ball.transform.localScale.y + growth, 0f);
    }

}
