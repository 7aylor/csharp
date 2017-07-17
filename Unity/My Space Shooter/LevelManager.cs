using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


    //load a level with the given name
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    //quit the program
    public void ExitGame()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }

}
