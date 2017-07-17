using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Text score;
    public Text health;
    public static GameUI UI_Instance;

    private void Awake()
    {
        UI_Instance = GetComponent<GameUI>();
        UpdateHealth();
        UpdateScore();
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateHealth(int newHealth=100)
    {
        UI_Instance.health.text = "HEALTH: " + newHealth;
    }

    public void UpdateScore(int newScore=0)
    {
        UI_Instance.score.text = "SCORE: " + newScore;
    }
}