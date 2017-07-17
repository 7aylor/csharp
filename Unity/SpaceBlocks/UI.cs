using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public static Text numLivesText;
	// Use this for initialization
	void Start () {
        numLivesText = GameObject.Find("NumberOfLives").GetComponent<Text>();
        PrintNumberOfLives();
    }

    public static void PrintNumberOfLives()
    {
        numLivesText.text = "L i v e s : " + Ball.numberOfLives;
    }
}
