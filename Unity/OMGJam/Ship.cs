using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Ship : MonoBehaviour {

    public GameObject Explosion;
    public AudioClip ExplosionSound;
    public AudioClip hitSound;
    public AudioClip boom;
    Text score;
    ShipSpawner shipSpawner;
    float shipSpeed;
    int health;
    int shipScore;

	// Use this for initialization
	void Start () {

        foreach(Text t in FindObjectsOfType<Text>())
        {
            if(t.tag == "Score")
            {
                score = t;
                break;
            }
        }

        if(tag == "Ship_Light")
        {
            shipSpawner = findCorrectShipSpawner("ShipSpawner_Light");
            shipSpeed = 2f;
            health = 1;
            shipScore = 10;
        }
        else if (tag == "Ship_Medium")
        {
            shipSpawner = findCorrectShipSpawner("ShipSpawner_Medium");
            shipSpeed = 1f;
            health = 2;
            shipScore = 20;
        }
        else if (tag == "Ship_Heavy")
        {
            shipSpawner = findCorrectShipSpawner("ShipSpawner_Heavy");
            shipSpeed = 0.5f;
            health = 3;
            shipScore = 30;
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * shipSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health--;
        if(collision.gameObject.tag == "Cannon Ball")
        {
            if(health <= 0)
            {
                DestroyShip();
                if (collision.gameObject.name != "Gate")
                {
                    updateScore();
                }
            }
            else
            {
                AudioSource.PlayClipAtPoint(hitSound, Vector3.zero);
            }
        }
        else if(collision.gameObject.name == "Gate")
        {
            Debug.Log("Destroying gate");

            //destroy gate
            Destroy(collision.gameObject);

            //create an explosion
            Instantiate(Explosion, collision.transform.position, Quaternion.identity);

            AudioSource.PlayClipAtPoint(boom, Vector3.zero);

            //destroy ship
            DestroyShip();
        }
    }

    ShipSpawner findCorrectShipSpawner(string tag)
    {
        ShipSpawner[] shipSpawners = FindObjectsOfType<ShipSpawner>();

        foreach(ShipSpawner s in shipSpawners)
        {
            if(s.tag == tag)
            {
                return s;
            }
        }

        return null;
    }

    public int getShipScore()
    {
        return shipScore;
    }

    void updateScore()
    {
        if(score != null)
        {
            int currScore = Int32.Parse(score.text);
            currScore += shipScore;

            ScoreTracker.SetScore(currScore);

            Debug.Log(score);

            score.text = currScore.ToString();
        }
        else
        {
            Debug.LogError("No Score object found!");
        }
    }

    public void DestroyShip()
    {
        //instantiate explosion animation
        Instantiate(Explosion, transform.position, Quaternion.identity);

        //play the explosion sound
        AudioSource.PlayClipAtPoint(ExplosionSound, Vector3.zero);

        //decrease the number of total ships alive in the scene
        Rounds.Instance.TotalShipsAlive--;

        Debug.Log("Number of ships alive: " + Rounds.Instance.TotalShipsAlive);

        //decrease number of boats in their respective lane
        shipSpawner.decreaseBoatCount();

        //destroy the boat
        Destroy(gameObject);
    }
}
