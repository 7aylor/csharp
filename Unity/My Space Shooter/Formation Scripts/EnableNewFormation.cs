using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNewFormation : MonoBehaviour {

    //the current usable formations
    Formation[] formations;

    //current formation that is active with enemies spawned
    Formation currentFormation;

    //get the current usable formations and enable a random formation
	void Awake() {
        formations = FindObjectsOfType<Formation>();
        EnableRandomFormation();
	}

	void Update () {

        //if all the enemies are dead in the current formation
		if(currentFormation.getEnemyCount() <= 0)
        {
            //disable the current formation
            DisableCurrentFormation();

            //enable a new random formation
            EnableRandomFormation();
        }
	}

    //gets a random formatio and spawns enemies
    void EnableRandomFormation()
    {
        int randomIndex = Random.Range(0, formations.Length);
        currentFormation = formations[randomIndex];
        currentFormation.enabled = true;
        currentFormation.SpawnEnemies();
    }

    //disables the current formation
    void DisableCurrentFormation()
    {
        currentFormation.enabled = false;
    }

}
