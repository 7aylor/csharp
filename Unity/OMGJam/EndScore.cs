using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour {

    public Text score;

	// Use this for initialization
	void Start () {

        score.text = ScoreTracker.GetScore().ToString();
	}
}
