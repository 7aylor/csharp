using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

struct brickCoord
{
    public float x;
    public float y;
}

public class SceneCreator : MonoBehaviour {

    public Brick[] brickTypes;
    public Brick[] powerUps;
    public int levelNumber;

    private const int minSpawnBorderHeight = 4;
    private const int maxSpawnBorderHeight = 12;
    private const float minSpawnBorderWidth = 0.5f;
    private const float maxSpawnBorderWidth = 15.5f;
    private const float yShift = (1f/6f);
    private const float xShift = 0.5f;
    private int minNumBricks = 30;
    private int maxNumBricks = 300;

    private static int maxIndexX = 31;
    private static int maxIndexY = 24;
    private brickCoord[,] brickGrid = new brickCoord[maxIndexX, maxIndexY];


	// Use this for initialization
	void Awake () {
        //the level we are on in the game
        levelNumber = gameObject.scene.buildIndex;
        CreateGrid();
        //Instantiate(brickTypes[0], new Vector3(brickGrid[0,0].x, brickGrid[0,0].y, 0), Quaternion.identity);
        GenerateBricks();
    }
	
    void CreateGrid()
    {
        for(int i = 0; i < brickGrid.GetLength(0); i++)
        {
            for(int j = 0; j < brickGrid.GetLength(1); j++)
            {
                if(i == 0)
                {
                    brickGrid[i, j].x = 0.5f;
                }
                else
                {
                    brickGrid[i, j].x = brickGrid[i - 1, j].x +  0.5f;
                }
                if(j == 0)
                {
                    brickGrid[i, j].y = 4f + (1f/6f);
                }
                else
                {
                    brickGrid[i, j].y = brickGrid[i, j - 1].y + (1f/3f);
                }
                //Instantiate(brickTypes[0], new Vector3(brickGrid[i, j].x, brickGrid[i, j].y, 0), Quaternion.identity);
            }
        }
    }

    void GenerateBricks()
    {
        int randNumBricks = Random.Range(minNumBricks, maxNumBricks);
        print("random bricks: " + randNumBricks);

        for (int i = 0; i < randNumBricks; i++)
        {
            int randIndexX = Random.Range(0, maxIndexX);
            int randIndexY = Random.Range(0, maxIndexY);
            Vector3 randLocation = new Vector3(brickGrid[randIndexX, randIndexY].x, brickGrid[randIndexX, randIndexY].y, 0);

            while (
                  Physics2D.Raycast(randLocation, Vector3.left, 1f) == true  ||
                  Physics2D.Raycast(randLocation, Vector3.right, 1f) == true
                  )
            {
                Debug.Log("collision");
                if(randIndexX < maxIndexX)
                {
                    randIndexX ++;
                }
                if(randIndexY < maxIndexY)
                {
                    randIndexY++;
                }
                //randIndexX = Random.Range(0, maxIndexX);
                //randIndexY = Random.Range(0, maxIndexY);
                randLocation = new Vector3(brickGrid[randIndexX, randIndexY].x, brickGrid[randIndexX, randIndexY].y, 0);
            }

            Instantiate(brickTypes[0], randLocation, Quaternion.identity);

        }

        //Instantiate(brickTypes[0], new Vector3(0 + xShift, 0 + minSpawnBorderHeight, 0), Quaternion.identity);
    }

    void GeneratePowerUps()
    {

    }
    
    void ClampToGrid(ref float x, ref float y)
    {
        float wholeX = Mathf.Floor(x);
        float wholeY = Mathf.Floor(y);

        float leftOverX = x - wholeX;
        float leftOverY = y - wholeY;

        if (leftOverX <= 0.5)
        {
            leftOverX = Mathf.Clamp(leftOverX, 0, 0.5f);
        }
        else
        {
            leftOverX = Mathf.Clamp(leftOverX, 0.5f, 1f);
        }

        if (leftOverY > 0 && leftOverY <= (1f / 3f))
        {
            leftOverY = Mathf.Clamp(leftOverY, 0, (1f / 3f));
        }
        else if (leftOverY > (1f / 3f) && leftOverY <= (2f / 3f))
        {
            leftOverY = Mathf.Clamp(leftOverY, (1f / 3f), (2f / 3f));
        }
        else
        {
            leftOverY = Mathf.Clamp(leftOverY, (2f / 3f), 1f);
        }

        x = wholeX + leftOverX;
        y = wholeY + leftOverY;

        print("x: " + leftOverX + "    y: " + leftOverY);
    }

    void initBrickPosition(ref int x, ref int y, ref Vector3 loc)
    {
        x = Random.Range(0, maxIndexX);
        y = Random.Range(0, maxIndexY);
        loc = new Vector3(brickGrid[x, y].x, brickGrid[x, y].y, 0);
    }
}
