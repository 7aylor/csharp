using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

    int max;
    int min;
    int guess;
    int maxGuessesAllowed = 5;

    public Text text;

    // Use this for initialization
    void Start () {
        StartGame();
    }

    void StartGame(){

        max = 1000;
        min = 1;
        NextGuess();
    }
	

    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    void NextGuess()
    {
        //guess = (max + min) / 2;

        guess = Random.Range(min, max + 1);
        text.text = guess.ToString();
        maxGuessesAllowed--;
        if(maxGuessesAllowed <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

}
