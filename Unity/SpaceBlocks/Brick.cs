using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public SpriteRenderer[] damagedBricks;
    public static int brickCount;
    public AudioClip explosion;
    public GameObject squareParticles;

    private int hitCount = 0;
    private LevelManager levelManager;
    private GameObject[] bricksInScene;
    public static bool StickBallToPaddle = false;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        bricksInScene = GameObject.FindGameObjectsWithTag("Brick");
        brickCount = bricksInScene.Length;
        print("Starting brick count: " + brickCount);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        HitHandler();
        CheckForPowerUp();
    }

    //Check if the brick is a powerup brick
    void CheckForPowerUp()
    {
        //if its a Slow Ball, call the PowerUpSlowBall method for all balls
        if (gameObject.CompareTag("SlowBall"))
        {
            foreach (Ball b in FindObjectsOfType<Ball>())
            {
                Ball.PowerUpSlowBall(b);
            }
        }
        //if its a Grow Ball, call the PowerUpGrowBall method for all balls
        else if (gameObject.CompareTag("GrowBall"))
        {
            foreach (Ball b in FindObjectsOfType<Ball>())
            {
                Ball.PowerUpGrowBall(b);
            }
        }
        //if its a StickToPaddle, let the paddle know to stick the ball to the paddle
        else if (gameObject.CompareTag("StickToPaddle"))
        {
            StickBallToPaddle = true;
            Paddle.numOfSticksToPaddle = 0;
        }
    }

    void HitHandler()
    {
        //if the brick is not invincible
        if (!gameObject.CompareTag("Invincible"))
        {
            //increase the number of hits
            hitCount++;

            //if the hitcount is greater than the damaged bricks in the Sprite Render array
            if (hitCount >= damagedBricks.Length + 1)
            {
                //destroy the brick and emit particles
                DestroyBrick();
                EmitParticles();
            }
            //otherwise, change the sprite to make it look more damaged
            else
            {
                SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
                sr.sprite = damagedBricks[hitCount - 1].sprite;
            }
        }
    }

    void DestroyBrick()
    {
        //play the explosion sound effect
        AudioSource.PlayClipAtPoint(explosion, gameObject.transform.position);

        //decrease brick count in the scene if its a brick and not a powerup or invincible
        if (gameObject.CompareTag("Brick"))
        {
            brickCount--;
        }
        

        //destroy the brick
        Destroy(gameObject);
        //print("Bricks left: " + brickCount);

        print("Brick Count: " + brickCount);

        //check if we need to load the next level
        levelManager.CheckLoadNextLevel();
    }

    void EmitParticles()
    {
        //instantiate the particle effect
        GameObject particleEffect = Instantiate(squareParticles, gameObject.transform.position, Quaternion.identity) as GameObject;

        //get the particle system's main component
        ParticleSystem.MainModule setting = particleEffect.GetComponent<ParticleSystem>().main;


        //If the brick is a powerup (8 is the layer number of powerups)
        if (gameObject.layer == 8)
        {
            //set the color to red
            setting.startColor = new Color(223 / 255f, 1 / 255f, 1 / 255f, 1f);
        }
        else
        {
            //set the color of the particles to the brick color
            setting.startColor = gameObject.GetComponent<SpriteRenderer>().color;
        }

        //If there are left over particles, delete them
        DeleteOldParticles();
    }

    void DeleteOldParticles()
    {
        GameObject[] ps = GameObject.FindGameObjectsWithTag("Particle");

        foreach (GameObject p in ps)
        {
            ParticleSystem particle = p.GetComponent<ParticleSystem>();
            if (particle.isStopped)
            {
                print("destroying Particles. There are " + ps.Length + " particles");
                Destroy(p);
            }
        }
    }

}
