using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour {

    //the ship object
    public GameObject ourShip;

    //spawn sound
    public AudioClip splash;

    //where we will spawn the ship
    Transform spawnPosition;

    //random value that determines when a ship is spawned
    float spawnTimer;

    //counters to delay spawns
    int timeBetweenLight = 0;
    int timeBetweenMedium = 0;
    int timeBetweenHeavy = 0;

    //limit number of boats per lane
    int boatLimitPerLane = 2;

    //counts the number of current boats in a lane
    int boatCount = 0;

    //delays between spawns
    int waitBetweenSpawnsLight = 60;
    int waitBetweenSpawnsMedium = 90;
    int waitBetweenSpawnsHeavy = 180;

    private void Start()
    {
        //get the spawn position based on its ship time
        if(ourShip.name == "Ship_Light")
        {
            spawnPosition = GameObject.FindGameObjectWithTag("ShipSpawner_Light").transform;
        }
        else if (ourShip.name == "Ship_Medium")
        {
            spawnPosition = GameObject.FindGameObjectWithTag("ShipSpawner_Medium").transform;
        }
        else if (ourShip.name == "Ship_Heavy")
        {
            spawnPosition = GameObject.FindGameObjectWithTag("ShipSpawner_Heavy").transform;
        }

    }

    // Update is called once per frame
    void Update () {

        //get a new random every frame
        spawnTimer = Random.value;

        //increase the delay counters
        timeBetweenLight++;
        timeBetweenMedium++;
        timeBetweenHeavy++;

        if(Rounds.Instance.isInWaitRound == false)
        {
            //check to spawn light ship
            if (IsAbleToSpawnLightShip())
            {
                //spawn it
                SpawnShip();

                //reset time delay between another spawn
                timeBetweenLight = 0;
            }
            //check to spawn medium ship
            else if (IsAbleToSpawnMediumShip())
            {
                //spawn it
                SpawnShip();

                //reset time delay between another spawn
                timeBetweenMedium = 0;
            }
            //check to spawn heavy ship
            else if (IsAbleToSpawnHeavyShip())
            {
                //spawn it
                SpawnShip();

                //reset time delay between another spawn
                timeBetweenHeavy = 0;
            }
            //brings us to a wait round
            else if (CanGoToWaitRound())
            {
                Rounds.Instance.RoundsCleared++;
                Rounds.Instance.ResetRound();
            }
        }
    }

    private bool IsAbleToSpawnLightShip()
    {
        if (ourShip.name == "Ship_Light" && spawnTimer < 0.01 && boatCount < boatLimitPerLane
                && timeBetweenLight > waitBetweenSpawnsLight && Rounds.Instance.TotalShipsSpawned < Rounds.Instance.NumSpawnShips) // all that stuff you had
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsAbleToSpawnMediumShip()
    {
        if (ourShip.name == "Ship_Medium" && spawnTimer < 0.01 && boatCount < boatLimitPerLane
                && timeBetweenMedium > waitBetweenSpawnsMedium && Rounds.Instance.TotalShipsSpawned < Rounds.Instance.NumSpawnShips)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsAbleToSpawnHeavyShip()
    {
        if (ourShip.name == "Ship_Heavy" && spawnTimer < 0.01 && boatCount < boatLimitPerLane
                && timeBetweenHeavy > waitBetweenSpawnsHeavy && Rounds.Instance.TotalShipsSpawned < Rounds.Instance.NumSpawnShips)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CanGoToWaitRound()
    {
        if (Rounds.Instance.TotalShipsSpawned >= Rounds.Instance.NumSpawnShips && Rounds.Instance.TotalShipsAlive <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void SpawnShip()
    {
        AudioSource.PlayClipAtPoint(splash, Vector3.zero);

        //spawn the ship
        Instantiate(ourShip, spawnPosition);

        //increase counter of spawns this type of ship
        boatCount++;

        //increase number of ships that are alive
        Rounds.Instance.TotalShipsAlive++;

        //increase counter of total number of spawned ships
        Rounds.Instance.TotalShipsSpawned++;

        Debug.Log(Rounds.Instance.TotalShipsSpawned + "Ships have been spawned");
    }

    //public method to decrement boat count (the number of boats of the type spawned)
    public void decreaseBoatCount()
    {
        boatCount--;
    }
}

