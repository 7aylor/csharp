using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFormation : MonoBehaviour {

    public Formation[] possibleFormations;

    Formation currentFormation;


    private void Awake()
    {
        SpawnNewFormation();
    }

    private void Update()
    {
        //if there all enemies are dead in the current formation
        if (currentFormation.getEnemyCount() <= 0)
        {
            DestroyFormation(currentFormation);
            SpawnNewFormation();
        }
    }

    private void SpawnNewFormation()
    {

        Debug.Log("Called Spawn New Formation");

        //get a random formation index
        int formationIndex = Random.Range(0, possibleFormations.Length);

        //get the new formation
        currentFormation = possibleFormations[formationIndex];

        //spawn new formation
        Instantiate(currentFormation, possibleFormations[formationIndex].transform.position, Quaternion.identity);

        //spawn enemies in child locations
        currentFormation.SpawnEnemies();
    }

    void DestroyFormation(Formation formation)
    {
        foreach(Transform child in formation.transform)
        {
            DestroyImmediate(child.gameObject, true);
        }
        DestroyImmediate(formation.gameObject, true);
    }
}
