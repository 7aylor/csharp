using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour {

    //instance of our Singleton
    public static Rounds Instance;

    //text fields in the scene
    Text cannonBallsText, score, cannonBallBonus, roundText;

    //audio clips to play in the scene
    public AudioClip applause, bell;

    //number of ships that can be spawned this round
    public int NumSpawnShips;

    //max number of ships spawned
    public int MinShips, MaxShips;

    //number of ships that have been spawned
    public int TotalShipsSpawned;

    //rounds cleared
    public int RoundsCleared;

    //determines if we are in an in-between round state
    public bool isInWaitRound;

    //number of cannon ball that can be fired
    public int cannonBallsInStock;

    //total number of ships that are in the scene
    public int TotalShipsAlive;

    public int cannonBallsLeftAtEndOfRound;

    //ensures only one applause is playing
    bool isApplausePlaying = false;

    //delay to display current round
    int timeBetweenDisplayRound;

    //the time to wait until we display the round number
    int waitBetweenDisplayRound;

    //max number of cannonballs that can be in your stock
    int maxCannonBalls = 15;

    CannonBall[] cannonBallsStillInScene;

    private void Awake()
    {
        //if the Rounds instance hasn't been created
        if(Instance == null)
        {
            //set it to this instance
            Instance = this;
        }
    }

    // Use this for initialization
    void Start () {

        Text[] textObjs = FindObjectsOfType<Text>();

        foreach(Text t in textObjs)
        {
            if(t.name == "Round")
            {
                roundText = t;
            }
            else if(t.name == "CannonBalls")
            {
                cannonBallsText = t;
            }
            else if(t.name == "CannonBallsBonus")
            {
                cannonBallBonus = t;
            }
            else if(t.name == "Score")
            {
                score = t;
            }
        }

        //first round has 5 ship
        NumSpawnShips = 5;

        //max per round is 10
        MinShips = 5;
        MaxShips = 10;

        //no boats have been spawned to start
        TotalShipsSpawned = 0;

        //no ships start out alive
        TotalShipsAlive = 0;

        //no rounds have been cleared to start
        RoundsCleared = 0;

        //Start in wait round
        isInWaitRound = true;

        //start the display round at 0
        timeBetweenDisplayRound = 0;

        //total wait time in a display round
        waitBetweenDisplayRound = 180;

        //fill up the cannon ball stock
        cannonBallsInStock = maxCannonBalls;

    }

    private void Update()
    {
        if(isInWaitRound == true)
        {
            timeBetweenDisplayRound++;

            if(timeBetweenDisplayRound == 30)
            {
                //get the cannon balls that are still in the scene (typically if that are on top of the castle)
                cannonBallsStillInScene = FindObjectsOfType<CannonBall>();

                //loop through all remaining cannon balls and destroy them
                foreach(CannonBall c in cannonBallsStillInScene)
                {
                    Destroy(c);
                }

                //displays the round text that appears to inform the player what round they are about to play
                SetRoundText();
            }
            if(timeBetweenDisplayRound == waitBetweenDisplayRound)
            {
                AudioSource.PlayClipAtPoint(bell, Vector3.zero);
                roundText.enabled = false;
                cannonBallBonus.enabled = false;
                isInWaitRound = false;
            }
            if(RoundsCleared > 0 && isApplausePlaying == false)
            {
                AudioSource.PlayClipAtPoint(applause, Vector3.zero);
                isApplausePlaying = true;
            }
        }
    }

    void EnableShipSpanwers()
    {
        //get all of the ship spawners in the scene
        ShipSpawner[] spawners = GameObject.FindObjectsOfType<ShipSpawner>();

        //loop through them all and enable them
        foreach(ShipSpawner s in spawners)
        {
            s.gameObject.SetActive(true);
        }
    }

    void SetRoundText()
    {
        roundText.text = "Round " + (RoundsCleared + 1).ToString();
        roundText.enabled = true;

        if (RoundsCleared > 0)
        {
            int currScore = ScoreTracker.GetScore();
            int bonus = cannonBallsLeftAtEndOfRound * 5;
            currScore += bonus;
            cannonBallBonus.text = "Cannon Ball Bonus +" + bonus + " (" + cannonBallsLeftAtEndOfRound + "x5)";
            cannonBallBonus.enabled = true;
            updateScore(bonus);
        }
    }

    public void ResetRound()
    {
        isInWaitRound = true;
        timeBetweenDisplayRound = 0;
        TotalShipsAlive = 0;
        TotalShipsSpawned = 0;
        NumSpawnShips = UnityEngine.Random.Range(MinShips, MaxShips);
        cannonBallsInStock = CalculateNumberOfCannonBalls(NumSpawnShips);
        cannonBallsText.text = Rounds.Instance.cannonBallsInStock.ToString();
        isApplausePlaying = false;
    }

    int CalculateNumberOfCannonBalls(int numShipsSpawned)
    {
        return 3 * numShipsSpawned;
    }

    void updateScore(int bonus)
    {
        int currScore = Int32.Parse(score.text);
        currScore += bonus;
        ScoreTracker.SetScore(currScore);
        score.text = currScore.ToString();
    }
}
