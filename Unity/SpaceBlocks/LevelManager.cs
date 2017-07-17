using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour{

    //loads the level passed to the function
    public void LoadLevel(string scene)
    {
        Brick.brickCount = 0;
        SceneManager.LoadScene(scene);
    }

    public void LoadNextLevel()
    {
        //get the current scene
        Scene currentScene = SceneManager.GetActiveScene();

        //get the index of the next scene
        int nextSceneIndex = currentScene.buildIndex + 1;

        //reset brick count
        Brick.brickCount = 0;

        //if the next scene is the lose screen, that means we won the game
        if (SceneManager.sceneCountInBuildSettings - nextSceneIndex == 2)
        {
            //load the last scene which is the win screen
            SceneManager.LoadScene("Win Menu");
        }
        //otherwise, load the next scene
        else
        {
            Ball.numberOfLives++;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    //quits the applications
    public void Quit()
    {
        //print("Quitting");
        Application.Quit();
    }

    public void CheckLoadNextLevel()
    {
        if(Brick.brickCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
